﻿using StableDiffusionGui.Main;
using StableDiffusionGui.MiscUtils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StableDiffusionGui.Forms
{
    public partial class RealtimeLoggerForm : Form
    {
        private float _defaultFontSize;

        public RealtimeLoggerForm()
        {
            InitializeComponent();
        }

        private void RealtimeLoggerForm_Load(object sender, EventArgs e)
        {
            _defaultFontSize = logBox.Font.Size;
            Logger.TextboxDebug = logBox;
            logBox.MouseWheel += logBox_MouseWheel;
        }

        private void logBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!InputUtils.IsHoldingCtrl) return;
            int sizeChange = e.Delta > 0 ? 1 : -1;
            logBox.Font = new Font(logBox.Font.Name, (logBox.Font.Size + sizeChange).Clamp(_defaultFontSize, _defaultFontSize * 2f), logBox.Font.Style, logBox.Font.Unit);
        }

        private void RealtimeLoggerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Escape))
                Close();
        }
    }
}
