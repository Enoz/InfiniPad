namespace InfiniPad
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
            this.label8 = new System.Windows.Forms.Label();
            this.textboxWindow = new System.Windows.Forms.TextBox();
            this.checkWindowCtrl = new System.Windows.Forms.CheckBox();
            this.checkWindowShift = new System.Windows.Forms.CheckBox();
            this.groupEditor = new System.Windows.Forms.GroupBox();
            this.trackHighlighterOpacity = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.textEdit = new System.Windows.Forms.TextBox();
            this.btnPenColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkEnabledEdit = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.chkHideStartup = new System.Windows.Forms.CheckBox();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.chkClipboard = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.tabShortcuts = new System.Windows.Forms.TabPage();
            this.tabEditor = new System.Windows.Forms.TabPage();
            this.tabWatermark = new System.Windows.Forms.TabPage();
            this.groupWatermark = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.trackScale = new System.Windows.Forms.TrackBar();
            this.trackOpacity = new System.Windows.Forms.TrackBar();
            this.pictureWatermark = new System.Windows.Forms.PictureBox();
            this.buttonChangeWatermark = new System.Windows.Forms.Button();
            this.checkEnabledWatermark = new System.Windows.Forms.CheckBox();
            this.tabScreenshot = new System.Windows.Forms.TabPage();
            this.btnMeasurementColor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOutlineColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.btnUnlink = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLinked = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUploadToAccount = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.textboxPin = new System.Windows.Forms.TextBox();
            this.btnRedirectAuth = new System.Windows.Forms.Button();
            this.chkRetry = new System.Windows.Forms.CheckBox();
            this.numRetries = new System.Windows.Forms.NumericUpDown();
            this.groupHotkeys.SuspendLayout();
            this.groupEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackHighlighterOpacity)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabShortcuts.SuspendLayout();
            this.tabEditor.SuspendLayout();
            this.tabWatermark.SuspendLayout();
            this.groupWatermark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWatermark)).BeginInit();
            this.tabScreenshot.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRetries)).BeginInit();
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
            this.groupHotkeys.Controls.Add(this.label8);
            this.groupHotkeys.Controls.Add(this.textboxWindow);
            this.groupHotkeys.Controls.Add(this.checkWindowCtrl);
            this.groupHotkeys.Controls.Add(this.checkWindowShift);
            this.groupHotkeys.Controls.Add(this.checkPartialCtrl);
            this.groupHotkeys.Controls.Add(this.checkMonitorCtrl);
            this.groupHotkeys.Controls.Add(this.textBoxPartial);
            this.groupHotkeys.Controls.Add(this.textBoxMonitor);
            this.groupHotkeys.Controls.Add(this.checkMonitorShift);
            this.groupHotkeys.Controls.Add(this.label1);
            this.groupHotkeys.Controls.Add(this.checkPartialShift);
            this.groupHotkeys.Controls.Add(this.label2);
            this.groupHotkeys.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupHotkeys.Location = new System.Drawing.Point(3, 42);
            this.groupHotkeys.Name = "groupHotkeys";
            this.groupHotkeys.Size = new System.Drawing.Size(335, 205);
            this.groupHotkeys.TabIndex = 6;
            this.groupHotkeys.TabStop = false;
            this.groupHotkeys.Text = "Keyboard Shortcuts";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(117, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Window Screenshot";
            // 
            // textboxWindow
            // 
            this.textboxWindow.Location = new System.Drawing.Point(226, 73);
            this.textboxWindow.Name = "textboxWindow";
            this.textboxWindow.Size = new System.Drawing.Size(29, 20);
            this.textboxWindow.TabIndex = 8;
            this.textboxWindow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxChanged);
            // 
            // checkWindowCtrl
            // 
            this.checkWindowCtrl.AutoSize = true;
            this.checkWindowCtrl.Location = new System.Drawing.Point(6, 76);
            this.checkWindowCtrl.Name = "checkWindowCtrl";
            this.checkWindowCtrl.Size = new System.Drawing.Size(54, 17);
            this.checkWindowCtrl.TabIndex = 7;
            this.checkWindowCtrl.Text = "CTRL";
            this.checkWindowCtrl.UseVisualStyleBackColor = true;
            // 
            // checkWindowShift
            // 
            this.checkWindowShift.AutoSize = true;
            this.checkWindowShift.Location = new System.Drawing.Point(66, 76);
            this.checkWindowShift.Name = "checkWindowShift";
            this.checkWindowShift.Size = new System.Drawing.Size(57, 17);
            this.checkWindowShift.TabIndex = 6;
            this.checkWindowShift.Text = "SHIFT";
            this.checkWindowShift.UseVisualStyleBackColor = true;
            // 
            // groupEditor
            // 
            this.groupEditor.Controls.Add(this.trackHighlighterOpacity);
            this.groupEditor.Controls.Add(this.label10);
            this.groupEditor.Controls.Add(this.textEdit);
            this.groupEditor.Controls.Add(this.btnPenColor);
            this.groupEditor.Controls.Add(this.label4);
            this.groupEditor.Controls.Add(this.label3);
            this.groupEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupEditor.Location = new System.Drawing.Point(3, 42);
            this.groupEditor.Name = "groupEditor";
            this.groupEditor.Size = new System.Drawing.Size(335, 205);
            this.groupEditor.TabIndex = 7;
            this.groupEditor.TabStop = false;
            this.groupEditor.Text = "Editor";
            // 
            // trackHighlighterOpacity
            // 
            this.trackHighlighterOpacity.AutoSize = false;
            this.trackHighlighterOpacity.Location = new System.Drawing.Point(110, 79);
            this.trackHighlighterOpacity.Maximum = 255;
            this.trackHighlighterOpacity.Minimum = 1;
            this.trackHighlighterOpacity.Name = "trackHighlighterOpacity";
            this.trackHighlighterOpacity.Size = new System.Drawing.Size(104, 28);
            this.trackHighlighterOpacity.TabIndex = 4;
            this.trackHighlighterOpacity.Value = 1;
            this.trackHighlighterOpacity.Scroll += new System.EventHandler(this.trackHighlighterOpacity_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Highlighter Opacity";
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
            this.btnPenColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabShortcuts);
            this.tabControl1.Controls.Add(this.tabEditor);
            this.tabControl1.Controls.Add(this.tabWatermark);
            this.tabControl1.Controls.Add(this.tabScreenshot);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(349, 276);
            this.tabControl1.TabIndex = 9;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.numRetries);
            this.tabGeneral.Controls.Add(this.chkRetry);
            this.tabGeneral.Controls.Add(this.chkHideStartup);
            this.tabGeneral.Controls.Add(this.btnUninstall);
            this.tabGeneral.Controls.Add(this.chkStartup);
            this.tabGeneral.Controls.Add(this.chkClipboard);
            this.tabGeneral.Controls.Add(this.btnReset);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(341, 250);
            this.tabGeneral.TabIndex = 4;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // chkHideStartup
            // 
            this.chkHideStartup.AutoSize = true;
            this.chkHideStartup.Location = new System.Drawing.Point(8, 135);
            this.chkHideStartup.Name = "chkHideStartup";
            this.chkHideStartup.Size = new System.Drawing.Size(102, 17);
            this.chkHideStartup.TabIndex = 7;
            this.chkHideStartup.Text = "Hide On Startup";
            this.chkHideStartup.UseVisualStyleBackColor = true;
            this.chkHideStartup.CheckedChanged += new System.EventHandler(this.chkHideStartup_CheckedChanged);
            // 
            // btnUninstall
            // 
            this.btnUninstall.Location = new System.Drawing.Point(6, 37);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(94, 23);
            this.btnUninstall.TabIndex = 6;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // chkStartup
            // 
            this.chkStartup.AutoSize = true;
            this.chkStartup.Location = new System.Drawing.Point(8, 112);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(100, 17);
            this.chkStartup.TabIndex = 5;
            this.chkStartup.Text = "Run On Startup";
            this.chkStartup.UseVisualStyleBackColor = true;
            this.chkStartup.CheckedChanged += new System.EventHandler(this.chkStartup_CheckedChanged);
            // 
            // chkClipboard
            // 
            this.chkClipboard.AutoSize = true;
            this.chkClipboard.Location = new System.Drawing.Point(8, 66);
            this.chkClipboard.Name = "chkClipboard";
            this.chkClipboard.Size = new System.Drawing.Size(109, 17);
            this.chkClipboard.TabIndex = 4;
            this.chkClipboard.Text = "Copy to Clipboard";
            this.chkClipboard.UseVisualStyleBackColor = true;
            this.chkClipboard.CheckedChanged += new System.EventHandler(this.chkClipboard_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(6, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset Settings";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tabShortcuts
            // 
            this.tabShortcuts.Controls.Add(this.checkEnabledHotkeys);
            this.tabShortcuts.Controls.Add(this.groupHotkeys);
            this.tabShortcuts.Location = new System.Drawing.Point(4, 22);
            this.tabShortcuts.Name = "tabShortcuts";
            this.tabShortcuts.Padding = new System.Windows.Forms.Padding(3);
            this.tabShortcuts.Size = new System.Drawing.Size(341, 250);
            this.tabShortcuts.TabIndex = 0;
            this.tabShortcuts.Text = "Shortcuts";
            this.tabShortcuts.UseVisualStyleBackColor = true;
            // 
            // tabEditor
            // 
            this.tabEditor.Controls.Add(this.checkEnabledEdit);
            this.tabEditor.Controls.Add(this.groupEditor);
            this.tabEditor.Location = new System.Drawing.Point(4, 22);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditor.Size = new System.Drawing.Size(341, 250);
            this.tabEditor.TabIndex = 1;
            this.tabEditor.Text = "Editor";
            this.tabEditor.UseVisualStyleBackColor = true;
            // 
            // tabWatermark
            // 
            this.tabWatermark.Controls.Add(this.groupWatermark);
            this.tabWatermark.Controls.Add(this.checkEnabledWatermark);
            this.tabWatermark.Location = new System.Drawing.Point(4, 22);
            this.tabWatermark.Name = "tabWatermark";
            this.tabWatermark.Padding = new System.Windows.Forms.Padding(3);
            this.tabWatermark.Size = new System.Drawing.Size(341, 250);
            this.tabWatermark.TabIndex = 2;
            this.tabWatermark.Text = "Watermark";
            this.tabWatermark.UseVisualStyleBackColor = true;
            // 
            // groupWatermark
            // 
            this.groupWatermark.Controls.Add(this.label7);
            this.groupWatermark.Controls.Add(this.trackScale);
            this.groupWatermark.Controls.Add(this.trackOpacity);
            this.groupWatermark.Controls.Add(this.pictureWatermark);
            this.groupWatermark.Controls.Add(this.buttonChangeWatermark);
            this.groupWatermark.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupWatermark.Location = new System.Drawing.Point(3, 46);
            this.groupWatermark.Name = "groupWatermark";
            this.groupWatermark.Size = new System.Drawing.Size(335, 201);
            this.groupWatermark.TabIndex = 1;
            this.groupWatermark.TabStop = false;
            this.groupWatermark.Text = "Watermark";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Scale";
            // 
            // trackScale
            // 
            this.trackScale.AutoSize = false;
            this.trackScale.Location = new System.Drawing.Point(54, 164);
            this.trackScale.Maximum = 30;
            this.trackScale.Minimum = 1;
            this.trackScale.Name = "trackScale";
            this.trackScale.Size = new System.Drawing.Size(186, 25);
            this.trackScale.TabIndex = 4;
            this.trackScale.Value = 30;
            this.trackScale.Scroll += new System.EventHandler(this.trackScale_Scroll);
            // 
            // trackOpacity
            // 
            this.trackOpacity.AutoSize = false;
            this.trackOpacity.Location = new System.Drawing.Point(246, 12);
            this.trackOpacity.Maximum = 100;
            this.trackOpacity.Minimum = 1;
            this.trackOpacity.Name = "trackOpacity";
            this.trackOpacity.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackOpacity.Size = new System.Drawing.Size(34, 146);
            this.trackOpacity.TabIndex = 2;
            this.trackOpacity.Value = 1;
            this.trackOpacity.Scroll += new System.EventHandler(this.trackOpacity_Scroll);
            // 
            // pictureWatermark
            // 
            this.pictureWatermark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureWatermark.Location = new System.Drawing.Point(17, 19);
            this.pictureWatermark.Name = "pictureWatermark";
            this.pictureWatermark.Size = new System.Drawing.Size(223, 139);
            this.pictureWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureWatermark.TabIndex = 1;
            this.pictureWatermark.TabStop = false;
            // 
            // buttonChangeWatermark
            // 
            this.buttonChangeWatermark.Location = new System.Drawing.Point(244, 164);
            this.buttonChangeWatermark.Name = "buttonChangeWatermark";
            this.buttonChangeWatermark.Size = new System.Drawing.Size(36, 25);
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
            // tabScreenshot
            // 
            this.tabScreenshot.Controls.Add(this.btnMeasurementColor);
            this.tabScreenshot.Controls.Add(this.label6);
            this.tabScreenshot.Controls.Add(this.btnOutlineColor);
            this.tabScreenshot.Controls.Add(this.label5);
            this.tabScreenshot.Location = new System.Drawing.Point(4, 22);
            this.tabScreenshot.Name = "tabScreenshot";
            this.tabScreenshot.Padding = new System.Windows.Forms.Padding(3);
            this.tabScreenshot.Size = new System.Drawing.Size(341, 250);
            this.tabScreenshot.TabIndex = 3;
            this.tabScreenshot.Text = "Screen Shot";
            this.tabScreenshot.UseVisualStyleBackColor = true;
            // 
            // btnMeasurementColor
            // 
            this.btnMeasurementColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMeasurementColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeasurementColor.Location = new System.Drawing.Point(114, 35);
            this.btnMeasurementColor.Name = "btnMeasurementColor";
            this.btnMeasurementColor.Size = new System.Drawing.Size(62, 23);
            this.btnMeasurementColor.TabIndex = 3;
            this.btnMeasurementColor.UseVisualStyleBackColor = true;
            this.btnMeasurementColor.Click += new System.EventHandler(this.btnMeasurementColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Measurement Color";
            // 
            // btnOutlineColor
            // 
            this.btnOutlineColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOutlineColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutlineColor.Location = new System.Drawing.Point(114, 6);
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblAccountID);
            this.tabPage1.Controls.Add(this.btnUnlink);
            this.tabPage1.Controls.Add(this.lblUsername);
            this.tabPage1.Controls.Add(this.lblLinked);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(341, 250);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Account";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblAccountID
            // 
            this.lblAccountID.AutoSize = true;
            this.lblAccountID.Location = new System.Drawing.Point(15, 133);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(69, 13);
            this.lblAccountID.TabIndex = 5;
            this.lblAccountID.Text = "account ID : ";
            // 
            // btnUnlink
            // 
            this.btnUnlink.Location = new System.Drawing.Point(18, 149);
            this.btnUnlink.Name = "btnUnlink";
            this.btnUnlink.Size = new System.Drawing.Size(52, 21);
            this.btnUnlink.TabIndex = 4;
            this.btnUnlink.Text = "unlink";
            this.btnUnlink.UseVisualStyleBackColor = true;
            this.btnUnlink.Click += new System.EventHandler(this.btnUnlink_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(15, 116);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(125, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Logged in as : Username";
            // 
            // lblLinked
            // 
            this.lblLinked.AutoSize = true;
            this.lblLinked.Location = new System.Drawing.Point(15, 103);
            this.lblLinked.Name = "lblLinked";
            this.lblLinked.Size = new System.Drawing.Size(42, 13);
            this.lblLinked.TabIndex = 2;
            this.lblLinked.Text = "Linked!";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUploadToAccount);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.textboxPin);
            this.groupBox1.Controls.Add(this.btnRedirectAuth);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imgur Authorization";
            // 
            // chkUploadToAccount
            // 
            this.chkUploadToAccount.AutoSize = true;
            this.chkUploadToAccount.Location = new System.Drawing.Point(10, 70);
            this.chkUploadToAccount.Name = "chkUploadToAccount";
            this.chkUploadToAccount.Size = new System.Drawing.Size(199, 17);
            this.chkUploadToAccount.TabIndex = 4;
            this.chkUploadToAccount.Text = "Upload Images Using Imgur Account";
            this.chkUploadToAccount.UseVisualStyleBackColor = true;
            this.chkUploadToAccount.CheckedChanged += new System.EventHandler(this.chkUploadToAccount_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(149, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "PIN";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(149, 41);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(154, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // textboxPin
            // 
            this.textboxPin.Location = new System.Drawing.Point(180, 19);
            this.textboxPin.Name = "textboxPin";
            this.textboxPin.Size = new System.Drawing.Size(123, 20);
            this.textboxPin.TabIndex = 1;
            // 
            // btnRedirectAuth
            // 
            this.btnRedirectAuth.Location = new System.Drawing.Point(10, 19);
            this.btnRedirectAuth.Name = "btnRedirectAuth";
            this.btnRedirectAuth.Size = new System.Drawing.Size(133, 45);
            this.btnRedirectAuth.TabIndex = 0;
            this.btnRedirectAuth.Text = "Authorize";
            this.btnRedirectAuth.UseVisualStyleBackColor = true;
            this.btnRedirectAuth.Click += new System.EventHandler(this.btnRedirectAuth_Click);
            // 
            // chkRetry
            // 
            this.chkRetry.AutoSize = true;
            this.chkRetry.Location = new System.Drawing.Point(8, 89);
            this.chkRetry.Name = "chkRetry";
            this.chkRetry.Size = new System.Drawing.Size(128, 17);
            this.chkRetry.TabIndex = 8;
            this.chkRetry.Text = "Retry If Upload Failed";
            this.chkRetry.UseVisualStyleBackColor = true;
            this.chkRetry.CheckedChanged += new System.EventHandler(this.chkShouldRetry_CheckChanged);
            // 
            // numRetries
            // 
            this.numRetries.Location = new System.Drawing.Point(133, 88);
            this.numRetries.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numRetries.Name = "numRetries";
            this.numRetries.Size = new System.Drawing.Size(29, 20);
            this.numRetries.TabIndex = 9;
            this.numRetries.ValueChanged += new System.EventHandler(this.numRetries_ValueChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 276);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackHighlighterOpacity)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabShortcuts.ResumeLayout(false);
            this.tabShortcuts.PerformLayout();
            this.tabEditor.ResumeLayout(false);
            this.tabEditor.PerformLayout();
            this.tabWatermark.ResumeLayout(false);
            this.tabWatermark.PerformLayout();
            this.groupWatermark.ResumeLayout(false);
            this.groupWatermark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWatermark)).EndInit();
            this.tabScreenshot.ResumeLayout(false);
            this.tabScreenshot.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRetries)).EndInit();
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
        private System.Windows.Forms.TabPage tabShortcuts;
        private System.Windows.Forms.TabPage tabEditor;
        private System.Windows.Forms.TabPage tabWatermark;
        private System.Windows.Forms.CheckBox checkEnabledWatermark;
        private System.Windows.Forms.GroupBox groupWatermark;
        private System.Windows.Forms.PictureBox pictureWatermark;
        private System.Windows.Forms.Button buttonChangeWatermark;
        private System.Windows.Forms.TrackBar trackOpacity;
        private System.Windows.Forms.TextBox textEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabScreenshot;
        private System.Windows.Forms.Button btnOutlineColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMeasurementColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chkClipboard;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.TrackBar trackScale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkHideStartup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textboxWindow;
        private System.Windows.Forms.CheckBox checkWindowCtrl;
        private System.Windows.Forms.CheckBox checkWindowShift;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox textboxPin;
        private System.Windows.Forms.Button btnRedirectAuth;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblLinked;
        private System.Windows.Forms.Button btnUnlink;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.CheckBox chkUploadToAccount;
        private System.Windows.Forms.TrackBar trackHighlighterOpacity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkRetry;
        private System.Windows.Forms.NumericUpDown numRetries;
    }
}