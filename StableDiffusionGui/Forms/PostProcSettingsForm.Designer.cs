﻿namespace StableDiffusionGui.Forms
{
    partial class PostProcSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostProcSettingsForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCodeformerFidelity = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.sliderCodeformerFidelity = new HTAlt.WinForms.HTSlider();
            this.labelCodeformerFidelity = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panelFaceRestorationStrength = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.sliderFaceRestoreStrength = new HTAlt.WinForms.HTSlider();
            this.labelFaceRestoreStrength = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelFaceRestorationMethod = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboxFaceRestoration = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelFaceRestorationEnable = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.checkboxFaceRestorationEnable = new System.Windows.Forms.CheckBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelUpscaling = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.comboxUpscale = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelUpscaleEnable = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.checkboxUpscaleEnable = new System.Windows.Forms.CheckBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panelCodeformerFidelity.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelFaceRestorationStrength.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panelFaceRestorationMethod.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelFaceRestorationEnable.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panelUpscaling.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelUpscaleEnable.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Yu Gothic UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(11, 9);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(218, 40);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Post-Processing";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panelCodeformerFidelity);
            this.panel1.Controls.Add(this.panelFaceRestorationStrength);
            this.panel1.Controls.Add(this.panelFaceRestorationMethod);
            this.panel1.Controls.Add(this.panelFaceRestorationEnable);
            this.panel1.Controls.Add(this.panelUpscaling);
            this.panel1.Controls.Add(this.panelUpscaleEnable);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Location = new System.Drawing.Point(12, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 287);
            this.panel1.TabIndex = 14;
            // 
            // panelCodeformerFidelity
            // 
            this.panelCodeformerFidelity.Controls.Add(this.tableLayoutPanel5);
            this.panelCodeformerFidelity.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCodeformerFidelity.Location = new System.Drawing.Point(0, 210);
            this.panelCodeformerFidelity.Name = "panelCodeformerFidelity";
            this.panelCodeformerFidelity.Size = new System.Drawing.Size(560, 35);
            this.panelCodeformerFidelity.TabIndex = 14;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(560, 35);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(283, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(274, 29);
            this.panel5.TabIndex = 88;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel6.Controls.Add(this.sliderCodeformerFidelity, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.labelCodeformerFidelity, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(268, 21);
            this.tableLayoutPanel6.TabIndex = 91;
            // 
            // sliderCodeformerFidelity
            // 
            this.sliderCodeformerFidelity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.sliderCodeformerFidelity.BorderRoundRectSize = new System.Drawing.Size(12, 12);
            this.sliderCodeformerFidelity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliderCodeformerFidelity.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderCodeformerFidelity.ForeColor = System.Drawing.Color.Black;
            this.sliderCodeformerFidelity.LargeChange = ((uint)(4u));
            this.sliderCodeformerFidelity.Location = new System.Drawing.Point(0, 0);
            this.sliderCodeformerFidelity.Margin = new System.Windows.Forms.Padding(0);
            this.sliderCodeformerFidelity.Maximum = 20;
            this.sliderCodeformerFidelity.Name = "sliderCodeformerFidelity";
            this.sliderCodeformerFidelity.OverlayColor = System.Drawing.Color.White;
            this.sliderCodeformerFidelity.Size = new System.Drawing.Size(223, 21);
            this.sliderCodeformerFidelity.SmallChange = ((uint)(1u));
            this.sliderCodeformerFidelity.TabIndex = 4;
            this.sliderCodeformerFidelity.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderCodeformerFidelity.ThumbSize = new System.Drawing.Size(14, 14);
            this.toolTip.SetToolTip(this.sliderCodeformerFidelity, "0 produces high quality but low accuracy. 1 produces high accuracy but low qualit" +
        "y.");
            this.sliderCodeformerFidelity.Value = 1;
            this.sliderCodeformerFidelity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderCodeformerFidelity_Scroll);
            // 
            // labelCodeformerFidelity
            // 
            this.labelCodeformerFidelity.AutoSize = true;
            this.labelCodeformerFidelity.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelCodeformerFidelity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodeformerFidelity.ForeColor = System.Drawing.Color.Silver;
            this.labelCodeformerFidelity.Location = new System.Drawing.Point(230, 0);
            this.labelCodeformerFidelity.Name = "labelCodeformerFidelity";
            this.labelCodeformerFidelity.Size = new System.Drawing.Size(35, 21);
            this.labelCodeformerFidelity.TabIndex = 5;
            this.labelCodeformerFidelity.Text = "1000";
            this.labelCodeformerFidelity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(274, 29);
            this.panel6.TabIndex = 87;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "CodeFormer Fidelity";
            // 
            // panelFaceRestorationStrength
            // 
            this.panelFaceRestorationStrength.Controls.Add(this.tableLayoutPanel2);
            this.panelFaceRestorationStrength.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFaceRestorationStrength.Location = new System.Drawing.Point(0, 175);
            this.panelFaceRestorationStrength.Name = "panelFaceRestorationStrength";
            this.panelFaceRestorationStrength.Size = new System.Drawing.Size(560, 35);
            this.panelFaceRestorationStrength.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel10, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel9, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(560, 35);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.tableLayoutPanel4);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(283, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(274, 29);
            this.panel10.TabIndex = 88;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel4.Controls.Add(this.sliderFaceRestoreStrength, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelFaceRestoreStrength, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(268, 21);
            this.tableLayoutPanel4.TabIndex = 91;
            // 
            // sliderFaceRestoreStrength
            // 
            this.sliderFaceRestoreStrength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.sliderFaceRestoreStrength.BorderRoundRectSize = new System.Drawing.Size(12, 12);
            this.sliderFaceRestoreStrength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliderFaceRestoreStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderFaceRestoreStrength.ForeColor = System.Drawing.Color.Black;
            this.sliderFaceRestoreStrength.LargeChange = ((uint)(4u));
            this.sliderFaceRestoreStrength.Location = new System.Drawing.Point(0, 0);
            this.sliderFaceRestoreStrength.Margin = new System.Windows.Forms.Padding(0);
            this.sliderFaceRestoreStrength.Maximum = 20;
            this.sliderFaceRestoreStrength.Name = "sliderFaceRestoreStrength";
            this.sliderFaceRestoreStrength.OverlayColor = System.Drawing.Color.White;
            this.sliderFaceRestoreStrength.Size = new System.Drawing.Size(223, 21);
            this.sliderFaceRestoreStrength.SmallChange = ((uint)(1u));
            this.sliderFaceRestoreStrength.TabIndex = 4;
            this.sliderFaceRestoreStrength.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderFaceRestoreStrength.ThumbSize = new System.Drawing.Size(14, 14);
            this.toolTip.SetToolTip(this.sliderFaceRestoreStrength, "0 = Off, 1 = Full Restoration");
            this.sliderFaceRestoreStrength.Value = 1;
            this.sliderFaceRestoreStrength.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderFaceRestoreStrength_Scroll);
            // 
            // labelFaceRestoreStrength
            // 
            this.labelFaceRestoreStrength.AutoSize = true;
            this.labelFaceRestoreStrength.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelFaceRestoreStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFaceRestoreStrength.ForeColor = System.Drawing.Color.Silver;
            this.labelFaceRestoreStrength.Location = new System.Drawing.Point(230, 0);
            this.labelFaceRestoreStrength.Name = "labelFaceRestoreStrength";
            this.labelFaceRestoreStrength.Size = new System.Drawing.Size(35, 21);
            this.labelFaceRestoreStrength.TabIndex = 5;
            this.labelFaceRestoreStrength.Text = "1000";
            this.labelFaceRestoreStrength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(274, 29);
            this.panel9.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Face Restoration Strength";
            // 
            // panelFaceRestorationMethod
            // 
            this.panelFaceRestorationMethod.Controls.Add(this.tableLayoutPanel3);
            this.panelFaceRestorationMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFaceRestorationMethod.Location = new System.Drawing.Point(0, 140);
            this.panelFaceRestorationMethod.Name = "panelFaceRestorationMethod";
            this.panelFaceRestorationMethod.Size = new System.Drawing.Size(560, 35);
            this.panelFaceRestorationMethod.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(560, 35);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboxFaceRestoration);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(283, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 29);
            this.panel3.TabIndex = 86;
            // 
            // comboxFaceRestoration
            // 
            this.comboxFaceRestoration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboxFaceRestoration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxFaceRestoration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboxFaceRestoration.ForeColor = System.Drawing.Color.White;
            this.comboxFaceRestoration.FormattingEnabled = true;
            this.comboxFaceRestoration.Location = new System.Drawing.Point(0, 5);
            this.comboxFaceRestoration.Name = "comboxFaceRestoration";
            this.comboxFaceRestoration.Size = new System.Drawing.Size(150, 21);
            this.comboxFaceRestoration.TabIndex = 106;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(274, 29);
            this.panel4.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Face Restoration Method";
            // 
            // panelFaceRestorationEnable
            // 
            this.panelFaceRestorationEnable.Controls.Add(this.tableLayoutPanel8);
            this.panelFaceRestorationEnable.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFaceRestorationEnable.Location = new System.Drawing.Point(0, 105);
            this.panelFaceRestorationEnable.Name = "panelFaceRestorationEnable";
            this.panelFaceRestorationEnable.Size = new System.Drawing.Size(560, 35);
            this.panelFaceRestorationEnable.TabIndex = 27;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.panel15, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.panel16, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(560, 35);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.checkboxFaceRestorationEnable);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(283, 3);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(274, 29);
            this.panel15.TabIndex = 88;
            // 
            // checkboxFaceRestorationEnable
            // 
            this.checkboxFaceRestorationEnable.AutoSize = true;
            this.checkboxFaceRestorationEnable.Location = new System.Drawing.Point(5, 7);
            this.checkboxFaceRestorationEnable.Name = "checkboxFaceRestorationEnable";
            this.checkboxFaceRestorationEnable.Size = new System.Drawing.Size(15, 14);
            this.checkboxFaceRestorationEnable.TabIndex = 87;
            this.checkboxFaceRestorationEnable.UseVisualStyleBackColor = true;
            this.checkboxFaceRestorationEnable.CheckedChanged += new System.EventHandler(this.checkboxFaceRestorationEnable_CheckedChanged);
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.label5);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(3, 3);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(274, 29);
            this.panel16.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 13);
            this.label5.TabIndex = 85;
            this.label5.Text = "Run Face Restoration for Every Generated Image";
            // 
            // panelUpscaling
            // 
            this.panelUpscaling.Controls.Add(this.tableLayoutPanel1);
            this.panelUpscaling.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUpscaling.Location = new System.Drawing.Point(0, 70);
            this.panelUpscaling.Name = "panelUpscaling";
            this.panelUpscaling.Size = new System.Drawing.Size(560, 35);
            this.panelUpscaling.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel8, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 35);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.comboxUpscale);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(283, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(274, 29);
            this.panel8.TabIndex = 86;
            // 
            // comboxUpscale
            // 
            this.comboxUpscale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboxUpscale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxUpscale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboxUpscale.ForeColor = System.Drawing.Color.White;
            this.comboxUpscale.FormattingEnabled = true;
            this.comboxUpscale.Items.AddRange(new object[] {
            "Disabled",
            "2x",
            "4x"});
            this.comboxUpscale.Location = new System.Drawing.Point(0, 5);
            this.comboxUpscale.Name = "comboxUpscale";
            this.comboxUpscale.Size = new System.Drawing.Size(150, 21);
            this.comboxUpscale.TabIndex = 106;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(274, 29);
            this.panel7.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Upscaling Factor";
            // 
            // panelUpscaleEnable
            // 
            this.panelUpscaleEnable.Controls.Add(this.tableLayoutPanel7);
            this.panelUpscaleEnable.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUpscaleEnable.Location = new System.Drawing.Point(0, 35);
            this.panelUpscaleEnable.Name = "panelUpscaleEnable";
            this.panelUpscaleEnable.Size = new System.Drawing.Size(560, 35);
            this.panelUpscaleEnable.TabIndex = 26;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.panel13, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.panel14, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(560, 35);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.checkboxUpscaleEnable);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(283, 3);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(274, 29);
            this.panel13.TabIndex = 88;
            // 
            // checkboxUpscaleEnable
            // 
            this.checkboxUpscaleEnable.AutoSize = true;
            this.checkboxUpscaleEnable.Location = new System.Drawing.Point(5, 7);
            this.checkboxUpscaleEnable.Name = "checkboxUpscaleEnable";
            this.checkboxUpscaleEnable.Size = new System.Drawing.Size(15, 14);
            this.checkboxUpscaleEnable.TabIndex = 87;
            this.checkboxUpscaleEnable.UseVisualStyleBackColor = true;
            this.checkboxUpscaleEnable.CheckedChanged += new System.EventHandler(this.checkboxUpscaleEnable_CheckedChanged);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label7);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(3, 3);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(274, 29);
            this.panel14.TabIndex = 87;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 13);
            this.label7.TabIndex = 85;
            this.label7.Text = "Run Upscaling for Every Generated Image";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(560, 35);
            this.panel11.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "AI Effects";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 200;
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.ReshowDelay = 40;
            // 
            // PostProcSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titleLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PostProcSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Post-Processing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PostProcSettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.PostProcSettingsForm_Load);
            this.Shown += new System.EventHandler(this.PostProcSettingsForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panelCodeformerFidelity.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelFaceRestorationStrength.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panelFaceRestorationMethod.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelFaceRestorationEnable.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panelUpscaling.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelUpscaleEnable.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelFaceRestorationStrength;
        private System.Windows.Forms.Panel panelUpscaling;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private HTAlt.WinForms.HTSlider sliderFaceRestoreStrength;
        private System.Windows.Forms.Label labelFaceRestoreStrength;
        private System.Windows.Forms.ComboBox comboxUpscale;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panelFaceRestorationMethod;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboxFaceRestoration;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelCodeformerFidelity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private HTAlt.WinForms.HTSlider sliderCodeformerFidelity;
        private System.Windows.Forms.Label labelCodeformerFidelity;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelFaceRestorationEnable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.CheckBox checkboxFaceRestorationEnable;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelUpscaleEnable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.CheckBox checkboxUpscaleEnable;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label7;
    }
}