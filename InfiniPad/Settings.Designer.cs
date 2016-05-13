﻿namespace InfiniPad
{
    partial class Settings
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
            this.textBoxPartial = new System.Windows.Forms.TextBox();
            this.checkEnabledHotkeys = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkPartialShift = new System.Windows.Forms.CheckBox();
            this.checkPartialCtrl = new System.Windows.Forms.CheckBox();
            this.textBoxMonitor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkMonitorShift = new System.Windows.Forms.CheckBox();
            this.checkMonitorCtrl = new System.Windows.Forms.CheckBox();
            this.groupHotkeys = new System.Windows.Forms.GroupBox();
            this.groupEditor = new System.Windows.Forms.GroupBox();
            this.textEdit = new System.Windows.Forms.TextBox();
            this.btnPenColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkEnabledEdit = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupWatermark = new System.Windows.Forms.GroupBox();
            this.trackOpacity = new System.Windows.Forms.TrackBar();
            this.pictureWatermark = new System.Windows.Forms.PictureBox();
            this.buttonChangeWatermark = new System.Windows.Forms.Button();
            this.checkEnabledWatermark = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnOutlineColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupHotkeys.SuspendLayout();
            this.groupEditor.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupWatermark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWatermark)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPartial
            // 
            this.textBoxPartial.Location = new System.Drawing.Point(226, 17);
            this.textBoxPartial.Name = "textBoxPartial";
            this.textBoxPartial.Size = new System.Drawing.Size(29, 20);
            this.textBoxPartial.TabIndex = 0;
            this.textBoxPartial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxChanged);
            // 
            // checkEnabledHotkeys
            // 
            this.checkEnabledHotkeys.AutoSize = true;
            this.checkEnabledHotkeys.Location = new System.Drawing.Point(6, 6);
            this.checkEnabledHotkeys.Name = "checkEnabledHotkeys";
            this.checkEnabledHotkeys.Size = new System.Drawing.Size(107, 17);
            this.checkEnabledHotkeys.TabIndex = 1;
            this.checkEnabledHotkeys.Text = "Enable Shortcuts";
            this.checkEnabledHotkeys.UseVisualStyleBackColor = true;
            this.checkEnabledHotkeys.CheckedChanged += new System.EventHandler(this.checkEnabledHotkeys_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Region Screenshot";
            // 
            // checkPartialShift
            // 
            this.checkPartialShift.AutoSize = true;
            this.checkPartialShift.Location = new System.Drawing.Point(66, 19);
            this.checkPartialShift.Name = "checkPartialShift";
            this.checkPartialShift.Size = new System.Drawing.Size(57, 17);
            this.checkPartialShift.TabIndex = 5;
            this.checkPartialShift.Text = "SHIFT";
            this.checkPartialShift.UseVisualStyleBackColor = true;
            // 
            // checkPartialCtrl
            // 
            this.checkPartialCtrl.AutoSize = true;
            this.checkPartialCtrl.Location = new System.Drawing.Point(6, 19);
            this.checkPartialCtrl.Name = "checkPartialCtrl";
            this.checkPartialCtrl.Size = new System.Drawing.Size(54, 17);
            this.checkPartialCtrl.TabIndex = 5;
            this.checkPartialCtrl.Text = "CTRL";
            this.checkPartialCtrl.UseVisualStyleBackColor = true;
            // 
            // textBoxMonitor
            // 
            this.textBoxMonitor.Location = new System.Drawing.Point(226, 47);
            this.textBoxMonitor.Name = "textBoxMonitor";
            this.textBoxMonitor.Size = new System.Drawing.Size(29, 20);
            this.textBoxMonitor.TabIndex = 0;
            this.textBoxMonitor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Monitor Screenshot";
            // 
            // checkMonitorShift
            // 
            this.checkMonitorShift.AutoSize = true;
            this.checkMonitorShift.Location = new System.Drawing.Point(66, 49);
            this.checkMonitorShift.Name = "checkMonitorShift";
            this.checkMonitorShift.Size = new System.Drawing.Size(57, 17);
            this.checkMonitorShift.TabIndex = 5;
            this.checkMonitorShift.Text = "SHIFT";
            this.checkMonitorShift.UseVisualStyleBackColor = true;
            // 
            // checkMonitorCtrl
            // 
            this.checkMonitorCtrl.AutoSize = true;
            this.checkMonitorCtrl.Location = new System.Drawing.Point(6, 49);
            this.checkMonitorCtrl.Name = "checkMonitorCtrl";
            this.checkMonitorCtrl.Size = new System.Drawing.Size(54, 17);
            this.checkMonitorCtrl.TabIndex = 5;
            this.checkMonitorCtrl.Text = "CTRL";
            this.checkMonitorCtrl.UseVisualStyleBackColor = true;
            // 
            // groupHotkeys
            // 
            this.groupHotkeys.Controls.Add(this.checkPartialCtrl);
            this.groupHotkeys.Controls.Add(this.checkMonitorCtrl);
            this.groupHotkeys.Controls.Add(this.textBoxPartial);
            this.groupHotkeys.Controls.Add(this.textBoxMonitor);
            this.groupHotkeys.Controls.Add(this.checkMonitorShift);
            this.groupHotkeys.Controls.Add(this.label1);
            this.groupHotkeys.Controls.Add(this.checkPartialShift);
            this.groupHotkeys.Controls.Add(this.label2);
            this.groupHotkeys.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupHotkeys.Location = new System.Drawing.Point(3, 29);
            this.groupHotkeys.Name = "groupHotkeys";
            this.groupHotkeys.Size = new System.Drawing.Size(275, 205);
            this.groupHotkeys.TabIndex = 6;
            this.groupHotkeys.TabStop = false;
            this.groupHotkeys.Text = "Keyboard Shortcuts";
            // 
            // groupEditor
            // 
            this.groupEditor.Controls.Add(this.textEdit);
            this.groupEditor.Controls.Add(this.btnPenColor);
            this.groupEditor.Controls.Add(this.label4);
            this.groupEditor.Controls.Add(this.label3);
            this.groupEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupEditor.Location = new System.Drawing.Point(3, 29);
            this.groupEditor.Name = "groupEditor";
            this.groupEditor.Size = new System.Drawing.Size(275, 205);
            this.groupEditor.TabIndex = 7;
            this.groupEditor.TabStop = false;
            this.groupEditor.Text = "Editor";
            // 
            // textEdit
            // 
            this.textEdit.Location = new System.Drawing.Point(100, 53);
            this.textEdit.Name = "textEdit";
            this.textEdit.Size = new System.Drawing.Size(100, 20);
            this.textEdit.TabIndex = 2;
            this.textEdit.TextChanged += new System.EventHandler(this.textEdit_TextChanged);
            // 
            // btnPenColor
            // 
            this.btnPenColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPenColor.Font = new System.Drawing.Font("Lao UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPenColor.Location = new System.Drawing.Point(104, 19);
            this.btnPenColor.Name = "btnPenColor";
            this.btnPenColor.Size = new System.Drawing.Size(62, 23);
            this.btnPenColor.TabIndex = 1;
            this.btnPenColor.UseVisualStyleBackColor = true;
            this.btnPenColor.Click += new System.EventHandler(this.btnPenColor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Default Edit Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Default Pen Color";
            // 
            // checkEnabledEdit
            // 
            this.checkEnabledEdit.AutoSize = true;
            this.checkEnabledEdit.Location = new System.Drawing.Point(6, 6);
            this.checkEnabledEdit.Name = "checkEnabledEdit";
            this.checkEnabledEdit.Size = new System.Drawing.Size(89, 17);
            this.checkEnabledEdit.TabIndex = 8;
            this.checkEnabledEdit.Text = "Enable Editor";
            this.checkEnabledEdit.UseVisualStyleBackColor = true;
            this.checkEnabledEdit.CheckedChanged += new System.EventHandler(this.checkEnabledEdit_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(289, 263);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkEnabledHotkeys);
            this.tabPage1.Controls.Add(this.groupHotkeys);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(281, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Shortcuts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkEnabledEdit);
            this.tabPage2.Controls.Add(this.groupEditor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(281, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Editor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupWatermark);
            this.tabPage3.Controls.Add(this.checkEnabledWatermark);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(281, 237);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Watermark";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupWatermark
            // 
            this.groupWatermark.Controls.Add(this.trackOpacity);
            this.groupWatermark.Controls.Add(this.pictureWatermark);
            this.groupWatermark.Controls.Add(this.buttonChangeWatermark);
            this.groupWatermark.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupWatermark.Location = new System.Drawing.Point(3, 33);
            this.groupWatermark.Name = "groupWatermark";
            this.groupWatermark.Size = new System.Drawing.Size(275, 201);
            this.groupWatermark.TabIndex = 1;
            this.groupWatermark.TabStop = false;
            this.groupWatermark.Text = "Watermark";
            // 
            // trackOpacity
            // 
            this.trackOpacity.AutoSize = false;
            this.trackOpacity.Location = new System.Drawing.Point(42, 162);
            this.trackOpacity.Maximum = 100;
            this.trackOpacity.Minimum = 1;
            this.trackOpacity.Name = "trackOpacity";
            this.trackOpacity.Size = new System.Drawing.Size(217, 33);
            this.trackOpacity.TabIndex = 2;
            this.trackOpacity.Value = 1;
            this.trackOpacity.Scroll += new System.EventHandler(this.trackOpacity_Scroll);
            // 
            // pictureWatermark
            // 
            this.pictureWatermark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureWatermark.Location = new System.Drawing.Point(42, 19);
            this.pictureWatermark.Name = "pictureWatermark";
            this.pictureWatermark.Size = new System.Drawing.Size(217, 142);
            this.pictureWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureWatermark.TabIndex = 1;
            this.pictureWatermark.TabStop = false;
            // 
            // buttonChangeWatermark
            // 
            this.buttonChangeWatermark.Location = new System.Drawing.Point(6, 19);
            this.buttonChangeWatermark.Name = "buttonChangeWatermark";
            this.buttonChangeWatermark.Size = new System.Drawing.Size(30, 23);
            this.buttonChangeWatermark.TabIndex = 0;
            this.buttonChangeWatermark.Text = "...";
            this.buttonChangeWatermark.UseVisualStyleBackColor = true;
            this.buttonChangeWatermark.Click += new System.EventHandler(this.buttonChangeWatermark_Click);
            // 
            // checkEnabledWatermark
            // 
            this.checkEnabledWatermark.AutoSize = true;
            this.checkEnabledWatermark.Location = new System.Drawing.Point(6, 6);
            this.checkEnabledWatermark.Name = "checkEnabledWatermark";
            this.checkEnabledWatermark.Size = new System.Drawing.Size(120, 17);
            this.checkEnabledWatermark.TabIndex = 0;
            this.checkEnabledWatermark.Text = "Watermark Enabled";
            this.checkEnabledWatermark.UseVisualStyleBackColor = true;
            this.checkEnabledWatermark.CheckedChanged += new System.EventHandler(this.checkEnabledWatermark_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnOutlineColor);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(281, 237);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Screen Shot";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnOutlineColor
            // 
            this.btnOutlineColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOutlineColor.Font = new System.Drawing.Font("Lao UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutlineColor.Location = new System.Drawing.Point(83, 6);
            this.btnOutlineColor.Name = "btnOutlineColor";
            this.btnOutlineColor.Size = new System.Drawing.Size(62, 23);
            this.btnOutlineColor.TabIndex = 3;
            this.btnOutlineColor.UseVisualStyleBackColor = true;
            this.btnOutlineColor.Click += new System.EventHandler(this.btnOutlineColor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Outline Color";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 263);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupHotkeys.ResumeLayout(false);
            this.groupHotkeys.PerformLayout();
            this.groupEditor.ResumeLayout(false);
            this.groupEditor.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupWatermark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWatermark)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPartial;
        private System.Windows.Forms.CheckBox checkEnabledHotkeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkPartialShift;
        private System.Windows.Forms.CheckBox checkPartialCtrl;
        private System.Windows.Forms.TextBox textBoxMonitor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkMonitorShift;
        private System.Windows.Forms.CheckBox checkMonitorCtrl;
        private System.Windows.Forms.GroupBox groupHotkeys;
        private System.Windows.Forms.GroupBox groupEditor;
        private System.Windows.Forms.Button btnPenColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkEnabledEdit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkEnabledWatermark;
        private System.Windows.Forms.GroupBox groupWatermark;
        private System.Windows.Forms.PictureBox pictureWatermark;
        private System.Windows.Forms.Button buttonChangeWatermark;
        private System.Windows.Forms.TrackBar trackOpacity;
        private System.Windows.Forms.TextBox textEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnOutlineColor;
        private System.Windows.Forms.Label label5;
    }
}