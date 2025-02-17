﻿using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Taskbar;
using StableDiffusionGui.Controls;
using StableDiffusionGui.Data;
using StableDiffusionGui.Extensions;
using StableDiffusionGui.Forms;
using StableDiffusionGui.Installation;
using StableDiffusionGui.Io;
using StableDiffusionGui.Main;
using StableDiffusionGui.MiscUtils;
using StableDiffusionGui.Os;
using StableDiffusionGui.Ui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paths = StableDiffusionGui.Io.Paths;

namespace StableDiffusionGui
{
    public partial class MainForm : Form
    {
        [Flags]
        public enum EXECUTION_STATE : uint { ES_AWAYMODE_REQUIRED = 0x00000040, ES_CONTINUOUS = 0x80000000, ES_DISPLAY_REQUIRED = 0x00000002, ES_SYSTEM_REQUIRED = 0x00000001 }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags); // This should prevent Windows from going to sleep

        #region References

        public Button RunBtn { get { return runBtn; } }
        public TextBox TextboxPrompt { get { return textboxPrompt; } }
        public PictureBox PictBoxImgViewer { get { return pictBoxImgViewer; } }
        public Label LabelImgInfo { get { return labelImgInfo; } }
        public Label LabelImgPrompt { get { return labelImgPrompt; } }
        public Button BtnExpandPromptField { get { return btnExpandPromptField; } }
        public Panel PanelBg { get { return panel1; } }
        public CustomSlider SliderStrength { get { return sliderInitStrength; } }
        public CustomSlider SliderSteps { get { return sliderSteps; } }
        public CustomSlider SliderScale { get { return sliderScale; } }
        public ComboBox ComboxResW { get { return comboxResW; } }
        public ComboBox ComboxResH { get { return comboxResH; } }

        #endregion

        public bool IsInFocus() { return (ActiveForm == this); }

        private Size _defaultWindowSize;
        private float _defaultPromptFontSize;

        public MainForm()
        {
            InitializeComponent();
            Program.MainForm = this;
            _defaultWindowSize = Size;
            Opacity = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            _defaultPromptFontSize = textboxPrompt.Font.Size;
            Logger.Textbox = logBox;
            MinimumSize = Size;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUiElements();

            if (Program.Busy)
            {
                DialogResult dialogResult = UiUtils.ShowMessageBox($"The program is still busy. Are you sure you want to quit?", UiUtils.MessageType.Warning.ToString(), MessageBoxButtons.YesNo);
                e.Cancel = dialogResult != DialogResult.Yes;
            }
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            Refresh();
            pictBoxImgViewer.MouseWheel += pictBoxImgViewer_MouseWheel;
            textboxPrompt.MouseWheel += textboxPrompt_MouseWheel;
            SetUiElements();
            LoadUiElements();
            PromptHistory.Load();
            Setup.FixHardcodedPaths();
            Task.Run(() => MainUi.SetGpusInWindowTitle());
            upDownSeed.Text = "";
            MainUi.DoStartupChecks();
            RefreshAfterSettingsChanged();
            UpdateInitImgAndEmbeddingUi();

            await Task.Delay(1); // Don't ask. Just keep it here
            Opacity = 1.0;

            if (!Debugger.IsAttached)
                new WelcomeForm().ShowDialogForm(0f);

            panelDebugSendStdin.Visible = Debugger.IsAttached;
        }

        private void SetUiElements()
        {
            comboxSampler.FillFromEnum<Enums.StableDiffusion.Sampler>(MainUi.UiStrings);

            bool adv = Config.GetBool("checkboxAdvancedMode");
            comboxResW.SetItems(MainUi.Resolutions.Where(x => x <= (adv ? 2048 : 1024)).Select(x => x.ToString()), UiExtensions.SelectMode.Last);
            comboxResH.SetItems(MainUi.Resolutions.Where(x => x <= (adv ? 2048 : 1024)).Select(x => x.ToString()), UiExtensions.SelectMode.Last);
        }

        private void LoadUiElements()
        {
            ConfigParser.LoadGuiElement(upDownIterations);
            ConfigParser.LoadGuiElement(sliderSteps);
            ConfigParser.LoadGuiElement(sliderScale);
            ConfigParser.LoadGuiElement(comboxResH);
            ConfigParser.LoadGuiElement(comboxResW);
            ConfigParser.LoadComboxIndex(comboxSampler);
            ConfigParser.LoadGuiElement(sliderInitStrength);
        }

        private void SaveUiElements()
        {
            ConfigParser.SaveGuiElement(upDownIterations);
            ConfigParser.SaveGuiElement(sliderSteps);
            ConfigParser.SaveGuiElement(sliderScale);
            ConfigParser.SaveGuiElement(comboxResH);
            ConfigParser.SaveGuiElement(comboxResW);
            ConfigParser.SaveComboxIndex(comboxSampler);
            ConfigParser.SaveGuiElement(sliderInitStrength);
        }

        public void RefreshAfterSettingsChanged()
        {
            bool opt = Config.GetBool("checkboxOptimizedSd");

            btnEmbeddingBrowse.Visible = !opt; // Disable embedding browse btn when using optimizedSD
            panelSampler.Visible = !opt; // Disable sampler selection if using optimized mode
            panelSeamless.Visible = !opt; // Disable seamless option when using optimizedSD

            bool adv = Config.GetBool("checkboxAdvancedMode");

            upDownIterations.Maximum = !adv ? 1000 : 10000;
            sliderSteps.ActualMaximum = !adv ? 120 : 500;
            sliderSteps.ValueStep = !adv ? 5 : 1;
            sliderScale.ActualMaximum = !adv ? 25 : 50;
            comboxResW.SetItems(MainUi.Resolutions.Where(x => x <= (adv ? 2048 : 1024)).Select(x => x.ToString()), UiExtensions.SelectMode.Retain, UiExtensions.SelectMode.Last);
            comboxResH.SetItems(MainUi.Resolutions.Where(x => x <= (adv ? 2048 : 1024)).Select(x => x.ToString()), UiExtensions.SelectMode.Retain, UiExtensions.SelectMode.Last);
        }

        private void installerBtn_Click(object sender, EventArgs e)
        {
            new InstallerForm().ShowDialogForm();
        }

        public void CleanPrompt()
        {
            if (File.Exists(MainUi.CurrentEmbeddingPath) && Path.GetExtension(MainUi.CurrentEmbeddingPath).Lower() == ".bin")
            {
                string conceptName = Path.GetFileNameWithoutExtension(MainUi.CurrentEmbeddingPath);
                textboxPrompt.Text = textboxPrompt.Text.Replace("*", $"<{conceptName.Trim()}>");
            }

            var lines = textboxPrompt.Text.SplitIntoLines();
            textboxPrompt.Text = string.Join(Environment.NewLine, lines.Select(x => MainUi.SanitizePrompt(x)));

            if (upDownSeed.Text == "")
                SetSeed();
        }

        public void SetSeed(long seed = -1)
        {
            upDownSeed.Value = seed;

            if (seed < 0)
                upDownSeed.Text = "";
        }

        public void LoadMetadataIntoUi(ImageMetadata meta)
        {
            textboxPrompt.Text = meta.Prompt;
            sliderSteps.ActualValue = meta.Steps;
            sliderScale.ActualValue = (decimal)meta.Scale;
            comboxResW.Text = meta.GeneratedResolution.Width.ToString();
            comboxResH.Text = meta.GeneratedResolution.Height.ToString();
            upDownSeed.Value = meta.Seed;
            comboxSampler.SetIfTextMatches(meta.Sampler, true, MainUi.UiStrings);
            // MainUi.CurrentInitImgPaths = new[] { meta.InitImgName }.Where(x => string.IsNullOrWhiteSpace(x)).ToList(); // Does this even work if we only store the temp path?
            MainUi.CurrentInitImgPaths = null;

            if (meta.InitStrength > 0f)
                sliderInitStrength.ActualValue = (decimal)meta.InitStrength;

            UpdateInitImgAndEmbeddingUi();
        }

        public void LoadTtiSettingsIntoUi(string[] prompts)
        {
            textboxPrompt.Text = string.Join(Environment.NewLine, prompts);
        }

        public void LoadTtiSettingsIntoUi(TtiSettings s)
        {
            textboxPrompt.Text = string.Join(Environment.NewLine, s.Prompts);
            upDownIterations.Value = s.Iterations;

            try
            {
                sliderSteps.ActualValue = s.Params.Get("steps").FromJson<int>();
                sliderScale.ActualValue = (decimal)s.Params.Get("scales").FromJson<List<float>>().FirstOrDefault();
                comboxResW.Text = s.Params.Get("res").FromJson<Size>().Width.ToString();
                comboxResH.Text = s.Params.Get("res").FromJson<Size>().Height.ToString();
                upDownSeed.Value = s.Params.Get("seed").FromJson<long>();
                comboxSampler.SetIfTextMatches(s.Params.Get("sampler").FromJson<string>(), true, MainUi.UiStrings);
                MainUi.CurrentInitImgPaths = s.Params.Get("initImgs").FromJson<List<string>>();
                sliderInitStrength.ActualValue = (decimal)s.Params.Get("initStrengths").FromJson<List<float>>().FirstOrDefault();
                MainUi.CurrentEmbeddingPath = s.Params.Get("embedding").FromJson<string>();
                checkboxSeamless.Checked = s.Params.Get("seamless").FromJson<bool>();
                checkboxInpainting.Checked = s.Params.Get("inpainting").FromJson<string>() == "masked";
                checkboxHiresFix.Checked = s.Params.Get("hiresFix").FromJson<bool>();
                checkboxLockSeed.Checked = s.Params.Get("lockSeed").FromJson<bool>();
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to load generation settings. This can happen when you try to load prompts from an older version.");
            }


            UpdateInitImgAndEmbeddingUi();
        }

        public TtiSettings GetCurrentTtiSettings()
        {
            TtiSettings settings = new TtiSettings
            {
                Implementation = Config.GetBool("checkboxOptimizedSd") ? Implementation.StableDiffusionOptimized : Implementation.StableDiffusion,
                Prompts = textboxPrompt.Text.SplitIntoLines().Where(x => !string.IsNullOrWhiteSpace(x)).ToArray(),
                Iterations = (int)upDownIterations.Value,
                Params = new Dictionary<string, string>
                        {
                            { "steps", SliderSteps.ActualValueInt.ToJson() },
                            { "scales", MainUi.GetScales(textboxExtraScales.Text).ToJson() },
                            { "res", new Size(ComboxResW.Text.GetInt(), ComboxResH.Text.GetInt()).ToJson() },
                            { "seed", (upDownSeed.Value < 0 ? new Random().Next(0, int.MaxValue) : ((long)upDownSeed.Value)).ToJson() },
                            { "sampler", ((Enums.StableDiffusion.Sampler)comboxSampler.SelectedIndex).ToString().Lower().ToJson() },
                            { "initImgs", MainUi.CurrentInitImgPaths.ToJson() },
                            { "initStrengths", MainUi.GetInitStrengths(textboxExtraInitStrengths.Text).ToJson() },
                            { "embedding", MainUi.CurrentEmbeddingPath.ToJson() },
                            { "seamless", checkboxSeamless.Checked.ToJson() },
                            { "inpainting", (checkboxInpainting.Checked ? "masked" : "").ToJson() },
                            { "model", Config.Get(Config.Key.comboxSdModel).ToJson() },
                            { "hiresFix", checkboxHiresFix.Checked.ToJson() },
                            { "lockSeed", checkboxLockSeed.Checked.ToJson() },
                            { "vae", Config.Get(Config.Key.comboxSdModelVae).ToJson() },
                        },
            };

            return settings;
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            if (Program.Busy)
            {
                TextToImage.CancelManually();
                return;
            }

            if (MainUi.Queue.Count > 0)
            {
                generateAllQueuedPromptsToolStripMenuItem.Text = $"Generate Queued Prompts ({MainUi.Queue.Count})";
                menuStripRunQueue.Show(Cursor.Position);
            }
            else
            {
                Run();
            }
        }

        public void Run(bool fromQueue = false)
        {
            try
            {
                if (Program.Busy)
                {
                    TextToImage.Cancel();
                    return;
                }
                else
                {
                    TextToImage.Canceled = false;

                    if (!MainUi.IsInstalledWithWarning())
                        return;

                    Logger.ClearLogBox();
                    CleanPrompt();
                    UpdateInitImgAndEmbeddingUi();
                    InpaintingUtils.DeleteMaskedImage();

                    if (fromQueue)
                    {
                        if (MainUi.Queue.Where(x => x != null).Count() < 0)
                        {
                            TextToImage.Cancel("Queue is empty.");
                            return;
                        }

                        TextToImage.RunTti(MainUi.Queue.AsEnumerable().Reverse().ToList()); // Reverse list to use top entries first
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(textboxPrompt.Text))
                        {
                            TextToImage.Cancel("No prompt was entered.");
                            return;
                        }

                        TextToImage.RunTti(GetCurrentTtiSettings());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"{ex.Message}\n{ex.StackTrace}");
            }
        }

        public void SetWorking(Program.BusyState state, bool allowCancel = true)
        {
            Logger.Log($"SetWorking({state})", true);
            Program.State = state;
            SetProgress(-1);

            bool imageGen = state == Program.BusyState.ImageGeneration;

            runBtn.Text = imageGen ? "Cancel" : "Generate!";
            runBtn.ForeColor = imageGen ? Color.IndianRed : Color.White;
            Control[] controlsToDisable = new Control[] { };
            Control[] controlsToHide = new Control[] { };
            progressCircle.Visible = state != Program.BusyState.Standby;

            foreach (Control c in controlsToDisable)
                c.Enabled = !imageGen;

            foreach (Control c in controlsToHide)
                c.Visible = !imageGen;

            if (!imageGen)
                SetProgressImg(0);

            progressBarImg.Visible = imageGen;
        }

        public void SetProgress(int percent, bool taskbarProgress = true)
        {
            percent = percent.Clamp(0, 100);
            progressBar.Value = percent;
            progressBar.Refresh();

            if (taskbarProgress)
                TaskbarManager.Instance.SetProgressValue(percent, 100);
        }

        public void SetProgressImg(int percent, bool taskbarProgress = false)
        {
            percent = percent.Clamp(0, 100);
            progressBarImg.Value = percent;
            progressBarImg.Refresh();

            if (taskbarProgress)
                TaskbarManager.Instance.SetProgressValue(percent, 100);
        }

        private void btnPrevImg_Click(object sender, EventArgs e)
        {
            ImagePreview.Move(true);
        }

        private void btnNextImg_Click(object sender, EventArgs e)
        {
            ImagePreview.Move(false);
        }

        private void btnOpenOutFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Config.Get(Config.Key.textboxOutPath));
        }

        #region Link Buttons

        private void paypalBtn_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/paypalme/nmkd/8");
        }

        private void patreonBtn_Click(object sender, EventArgs e)
        {
            Process.Start("https://patreon.com/n00mkrad");
        }

        private void discordBtn_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/fZwWSnV5WA");
        }

        #endregion

        #region Output Image Menu Strip

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImagePreview.OpenCurrent();
        }

        private void openOutputFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImagePreview.OpenFolderOfCurrent();
        }

        private void copyImageToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OsUtils.SetClipboard(pictBoxImgViewer.Image);
        }

        private void copySeedToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OsUtils.SetClipboard(ImagePreview.CurrentImageMetadata.Seed.ToString());
        }

        private void useAsInitImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Busy)
            {
                UiUtils.ShowMessageBox("Please wait until the generation has finished.");
                return;
            }

            MainUi.HandleDroppedFiles(new string[] { ImagePreview.CurrentImagePath });
        }

        private void copyToFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImagePreview.CopyCurrentToFavs();
        }

        private void postProcessImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPostProcessMenu();
        }

        #endregion

        private void cliButton_Click(object sender, EventArgs e)
        {
            menuStripDevTools.Show(Cursor.Position);
        }

        private void pictBoxImgViewer_Click(object sender, EventArgs e)
        {
            pictBoxImgViewer.Focus();

            if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                if (!string.IsNullOrWhiteSpace(ImagePreview.CurrentImagePath) && File.Exists(ImagePreview.CurrentImagePath))
                    menuStripOutputImg.Show(Cursor.Position);
            }
            else
            {
                if (pictBoxImgViewer.Image != null)
                    ImagePopup.Show(pictBoxImgViewer.Image, ImagePopupForm.SizeMode.Percent100);
            }
        }

        #region Drag N Drop

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            MainUi.HandleDroppedFiles((string[])e.Data.GetData(DataFormats.FileDrop));
        }

        #endregion

        #region Init Img and Embedding

        private void btnInitImgBrowse_Click(object sender, EventArgs e)
        {
            if (Program.Busy)
                return;

            if (MainUi.CurrentInitImgPaths != null)
            {
                MainUi.CurrentInitImgPaths = null;
            }
            else
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog { InitialDirectory = MainUi.CurrentInitImgPaths?[0].GetParentDirOfFile(), IsFolderPicker = false, Multiselect = true };

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    var paths = dialog.FileNames.Where(path => Constants.FileExts.ValidImages.Contains(Path.GetExtension(path).Lower()));

                    if (paths.Count() > 0)
                        MainUi.HandleDroppedFiles(paths.ToArray(), true);
                    else
                        UiUtils.ShowMessageBox(dialog.FileNames.Count() == 1 ? "Invalid file type." : "None of the selected files are valid.");
                }
            }

            UpdateInitImgAndEmbeddingUi();
        }

        public void UpdateInitImgAndEmbeddingUi()
        {
            TtiUtils.CleanInitImageList();

            if (!string.IsNullOrWhiteSpace(MainUi.CurrentEmbeddingPath) && !File.Exists(MainUi.CurrentEmbeddingPath))
            {
                MainUi.CurrentEmbeddingPath = "";
                Logger.Log($"Concept was cleared because the file no longer exists.");
            }

            bool img2img = MainUi.CurrentInitImgPaths != null;
            panelInpainting.Visible = img2img;
            panelInitImgStrength.Visible = img2img;
            btnInitImgBrowse.Text = img2img ? $"Clear Image{(MainUi.CurrentInitImgPaths.Count == 1 ? "" : "s")}" : "Load Image(s)";

            bool embeddingExists = File.Exists(MainUi.CurrentEmbeddingPath);
            btnEmbeddingBrowse.Text = embeddingExists ? "Clear Concept" : "Load Concept";

            labelCurrentImage.Text = !img2img ? "No initialization image loaded." : (MainUi.CurrentInitImgPaths.Count == 1 ? $"Currently using {Path.GetFileName(MainUi.CurrentInitImgPaths[0]).Trunc(30)}" : $"Currently using {MainUi.CurrentInitImgPaths.Count} images.");
            labelCurrentConcept.Text = string.IsNullOrWhiteSpace(MainUi.CurrentEmbeddingPath) ? "No trained concept loaded." : $"Currently using {Path.GetFileName(MainUi.CurrentEmbeddingPath).Trunc(30)}";

            RefreshAfterSettingsChanged();
        }

        private void btnEmbeddingBrowse_Click(object sender, EventArgs e)
        {
            if (Program.Busy)
                return;

            if (Config.GetBool("checkboxOptimizedSd"))
            {
                Logger.Log("Not supported in Low Memory Mode.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(MainUi.CurrentEmbeddingPath))
            {
                MainUi.CurrentEmbeddingPath = "";
            }
            else
            {
                string initDir = File.Exists(MainUi.CurrentEmbeddingPath) ? MainUi.CurrentEmbeddingPath.GetParentDirOfFile() : Path.Combine(Paths.GetExeDir(), "ExampleConcepts");

                Logger.Log(initDir);

                CommonOpenFileDialog dialog = new CommonOpenFileDialog { InitialDirectory = initDir, IsFolderPicker = false };

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    if (Constants.FileExts.ValidEmbeddings.Contains(Path.GetExtension(dialog.FileName.Lower())))
                        MainUi.CurrentEmbeddingPath = dialog.FileName;
                    else
                        UiUtils.ShowMessageBox("Invalid file type.");
                }
            }

            UpdateInitImgAndEmbeddingUi();
        }

        #endregion

        private void btnDebug_Click(object sender, EventArgs e)
        {
            menuStripLogs.Items.Clear();
            var openLogs = menuStripLogs.Items.Add($"Open Logs Folder");
            openLogs.Click += (s, ea) => { Process.Start("explorer", Paths.GetLogPath().Wrap()); };

            foreach (var log in Logger.SessionLogs)
            {
                ToolStripItem newItem = menuStripLogs.Items.Add($"Copy {log.Key}");
                newItem.Click += (s, ea) => { OsUtils.SetClipboard(Logger.SessionLogs[log.Key]); };
            }

            menuStripLogs.Show(Cursor.Position);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialogForm(0.5f);
        }

        private void btnPostProc_Click(object sender, EventArgs e)
        {
            if (Config.GetBool("checkboxOptimizedSd"))
            {
                UiUtils.ShowMessageBox("Post-processing is not available when using Low Memory Mode.");
                return;
            }

            new PostProcSettingsForm().ShowDialogForm();
        }

        private void btnExpandPromptField_Click(object sender, EventArgs e)
        {
            MainUi.SetPromptFieldSize(MainUi.PromptFieldSizeMode.Toggle);
        }

        private void btnSeedUsePrevious_Click(object sender, EventArgs e)
        {
            upDownSeed.Value = TextToImage.PreviousSeed;
        }

        private void btnSeedResetToRandom_Click(object sender, EventArgs e)
        {
            upDownSeed.Value = -1;
            upDownSeed.Text = "";
        }

        private void btnPromptHistory_Click(object sender, EventArgs e)
        {
            new PromptListForm(PromptListForm.ListMode.History).ShowDialogForm();
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            if (Program.Busy)
                return;

            new PromptListForm(PromptListForm.ListMode.Queue).ShowDialogForm();
        }

        private void generateCurrentPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run();
        }

        private void generateAllQueuedPromptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run(true);
        }

        public void UpdateInpaintUi()
        {
            btnResetMask.Visible = InpaintingUtils.CurrentMask != null;
        }

        private void btnResetMask_Click(object sender, EventArgs e)
        {
            InpaintingUtils.CurrentMask = null;
        }

        private void pictBoxImgViewer_MouseWheel(object sender, MouseEventArgs e)
        {
            ImagePreview.Move(e.Delta > 0);
        }

        private void textboxCliTest_DoubleClick(object sender, EventArgs e)
        {
            TtiProcess.WriteStdIn(textboxCliTest.Text);
            textboxCliTest.Text = "";
        }

        private void addCurrentSettingsToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = GetCurrentTtiSettings();

            if (settings.Prompts.Where(x => !string.IsNullOrWhiteSpace(x)).Any())
                MainUi.Queue.Add(settings);
        }

        private void btnQueue_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                menuStripAddToQueue.Show(Cursor.Position);
        }

        private void reGenerateImageWithCurrentSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Busy)
            {
                UiUtils.ShowMessageBox("Please wait until the current process has finished.");
                return;
            }

            var prevSeedVal = upDownSeed.Value;
            var prevIterVal = upDownIterations.Value;
            upDownSeed.Value = ImagePreview.CurrentImageMetadata.Seed;
            upDownIterations.Value = 1;
            runBtn_Click(null, null);
            SetSeed((long)prevSeedVal);
            upDownIterations.Value = prevIterVal;
        }

        private void textboxPrompt_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!InputUtils.IsHoldingCtrl) return;
            int sizeChange = e.Delta > 0 ? 1 : -1;
            textboxPrompt.Font = new Font(textboxPrompt.Font.Name, (textboxPrompt.Font.Size + sizeChange).Clamp(_defaultPromptFontSize, _defaultPromptFontSize * 2f), textboxPrompt.Font.Style, textboxPrompt.Font.Unit);
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            MainUi.SetPromptFieldSize(MainUi.PromptFieldSizeMode.Collapse);
        }

        private void btnDeleteBatch_Click(object sender, EventArgs e)
        {
            menuStripDeleteImages.Show(Cursor.Position);
        }

        private void deleteThisImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImagePreview.DeleteCurrent();
        }

        private void deleteAllCurrentImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImagePreview.DeleteAll();
        }

        private void MainForm_Up(object sender, KeyEventArgs e)
        {
            MainUiHotkeys.Handle(e.KeyData);
        }

        private void openDreampyCLIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Busy || !MainUi.IsInstalledWithWarning())
                return;

            TtiProcess.RunStableDiffusionCli(Config.Get(Config.Key.textboxOutPath), Config.Get(Config.Key.comboxSdModelVae));
        }

        private void openModelMergeToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MergeModelsForm().ShowDialogForm();
        }

        private void openModelPruningTrimmingToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PruneModelsForm().ShowDialogForm();
        }

        private void textboxPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;

                if (textboxPrompt.SelectionStart > 0)
                    SendKeys.Send("+{LEFT}{DEL}");
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel1.Focus();
        }

        private void viewLogInRealtimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RealtimeLoggerForm().Show();
        }

        private void trainDreamBoothModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DreamboothForm().ShowDialogForm();
        }

        private void fitWindowSizeToImageSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictBoxImgViewer.Image.Size == pictBoxImgViewer.Size)
                return;

            int formWidthWithoutImgViewer = Size.Width - pictBoxImgViewer.Width;
            int formHeightWithoutImgViewer = Size.Height - pictBoxImgViewer.Height;

            Size targetSize = new Size(pictBoxImgViewer.Image.Width + formWidthWithoutImgViewer, pictBoxImgViewer.Image.Height + formHeightWithoutImgViewer);
            Size = new Size(targetSize.Width.Clamp(512, int.MaxValue), targetSize.Height.Clamp(512, int.MaxValue));

            CenterToScreen();
        }

        private void labelImgPrompt_Click(object sender, EventArgs e)
        {
            OsUtils.SetClipboard(ImagePreview.CurrentImageMetadata.Prompt);
        }

        private void openCmdInCondaEnvironmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TtiProcess.StartCmdInSdCondaEnv();
        }

        public void ShowPostProcessMenu()
        {
            menuStripPostProcess.Show(Cursor.Position);
        }

        private void upscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TtiProcess.InvokeAiFix(ImagePreview.CurrentImagePath, new[] { TtiProcess.FixAction.Upscale }.ToList());
        }

        private void applyFaceRestorationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TtiProcess.InvokeAiFix(ImagePreview.CurrentImagePath, new[] { TtiProcess.FixAction.FaceRestoration }.ToList());
        }

        private void applyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TtiProcess.InvokeAiFix(ImagePreview.CurrentImagePath, new[] { TtiProcess.FixAction.Upscale, TtiProcess.FixAction.FaceRestoration }.ToList());
        }
    }
}
