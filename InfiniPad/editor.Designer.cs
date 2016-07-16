namespace InfiniPad
{
    partial class editor
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
            this.picEdit = new System.Windows.Forms.PictureBox();
            this.picPanel = new System.Windows.Forms.Panel();
            this.editGroupBox = new System.Windows.Forms.GroupBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.textDrawBox = new System.Windows.Forms.TextBox();
            this.textDrawButton = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.cmbPenSize = new System.Windows.Forms.ComboBox();
            this.btnPen = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCtrlRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            this.picPanel.SuspendLayout();
            this.editGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picEdit
            // 
            this.picEdit.Location = new System.Drawing.Point(0, 0);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(132, 94);
            this.picEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEdit.TabIndex = 0;
            this.picEdit.TabStop = false;
            this.picEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.picEdit_Paint);
            this.picEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picEdit_MouseDown);
            this.picEdit.MouseEnter += new System.EventHandler(this.picEdit_MouseEnter);
            this.picEdit.MouseLeave += new System.EventHandler(this.picEdit_MouseLeave);
            this.picEdit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picEdit_MouseMove);
            this.picEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picEdit_MouseUp);
            // 
            // picPanel
            // 
            this.picPanel.AutoScroll = true;
            this.picPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picPanel.Controls.Add(this.picEdit);
            this.picPanel.Location = new System.Drawing.Point(0, 27);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(673, 466);
            this.picPanel.TabIndex = 1;
            // 
            // editGroupBox
            // 
            this.editGroupBox.Controls.Add(this.btnColor);
            this.editGroupBox.Controls.Add(this.textDrawBox);
            this.editGroupBox.Controls.Add(this.textDrawButton);
            this.editGroupBox.Controls.Add(this.btnDone);
            this.editGroupBox.Controls.Add(this.cmbPenSize);
            this.editGroupBox.Controls.Add(this.btnPen);
            this.editGroupBox.Location = new System.Drawing.Point(3, 496);
            this.editGroupBox.Name = "editGroupBox";
            this.editGroupBox.Size = new System.Drawing.Size(670, 45);
            this.editGroupBox.TabIndex = 2;
            this.editGroupBox.TabStop = false;
            this.editGroupBox.Text = "Edit";
            // 
            // btnColor
            // 
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(109, 15);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(44, 25);
            this.btnColor.TabIndex = 5;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // textDrawBox
            // 
            this.textDrawBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textDrawBox.Location = new System.Drawing.Point(352, 19);
            this.textDrawBox.Name = "textDrawBox";
            this.textDrawBox.Size = new System.Drawing.Size(100, 20);
            this.textDrawBox.TabIndex = 4;
            this.textDrawBox.Text = "Text";
            // 
            // textDrawButton
            // 
            this.textDrawButton.Location = new System.Drawing.Point(458, 18);
            this.textDrawButton.Name = "textDrawButton";
            this.textDrawButton.Size = new System.Drawing.Size(39, 22);
            this.textDrawButton.TabIndex = 3;
            this.textDrawButton.Text = "Text";
            this.textDrawButton.UseVisualStyleBackColor = true;
            this.textDrawButton.Click += new System.EventHandler(this.textDrawButton_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(4, 14);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(99, 26);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.HandleUpload);
            // 
            // cmbPenSize
            // 
            this.cmbPenSize.FormattingEnabled = true;
            this.cmbPenSize.Location = new System.Drawing.Point(225, 18);
            this.cmbPenSize.Name = "cmbPenSize";
            this.cmbPenSize.Size = new System.Drawing.Size(121, 21);
            this.cmbPenSize.TabIndex = 1;
            this.cmbPenSize.SelectedIndexChanged += new System.EventHandler(this.cmbPenSize_SelectedIndexChanged);
            // 
            // btnPen
            // 
            this.btnPen.Location = new System.Drawing.Point(159, 15);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(60, 25);
            this.btnPen.TabIndex = 0;
            this.btnPen.Text = "Pen";
            this.btnPen.UseVisualStyleBackColor = true;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(681, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.copyToClipboardToolStripMenuItem,
            this.uploadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy To Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.uploadToolStripMenuItem.Text = "Upload to Imgur";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.HandleUpload);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.resetCtrlRToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo     Ctrl+Z";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // resetCtrlRToolStripMenuItem
            // 
            this.resetCtrlRToolStripMenuItem.Name = "resetCtrlRToolStripMenuItem";
            this.resetCtrlRToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetCtrlRToolStripMenuItem.Text = "Reset     Ctrl+R";
            this.resetCtrlRToolStripMenuItem.Click += new System.EventHandler(this.resetCtrlRToolStripMenuItem_Click);
            // 
            // editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(681, 545);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.editGroupBox);
            this.Controls.Add(this.picPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "editor";
            this.Resize += new System.EventHandler(this.editor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            this.picPanel.ResumeLayout(false);
            this.picPanel.PerformLayout();
            this.editGroupBox.ResumeLayout(false);
            this.editGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picEdit;
        private System.Windows.Forms.Panel picPanel;
        private System.Windows.Forms.GroupBox editGroupBox;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.ComboBox cmbPenSize;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetCtrlRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TextBox textDrawBox;
        private System.Windows.Forms.Button textDrawButton;
        private System.Windows.Forms.Button btnColor;
    }
}