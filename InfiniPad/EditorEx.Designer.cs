namespace InfiniPad
{
    partial class EditorEx
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
            this.panelWorkspace = new System.Windows.Forms.Panel();
            this.picEdit = new System.Windows.Forms.PictureBox();
            this.textboxTextToDraw = new System.Windows.Forms.TextBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.trackSize = new System.Windows.Forms.TrackBar();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCtrlRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.btnPen = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnBlur = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoCtrlZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoCtrlRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoCtrlZToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCtrlZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCrop = new System.Windows.Forms.Button();
            this.panelWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSize)).BeginInit();
            this.grpEdit.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkspace
            // 
            this.panelWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWorkspace.AutoSize = true;
            this.panelWorkspace.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelWorkspace.Controls.Add(this.picEdit);
            this.panelWorkspace.Location = new System.Drawing.Point(12, 27);
            this.panelWorkspace.Name = "panelWorkspace";
            this.panelWorkspace.Size = new System.Drawing.Size(845, 463);
            this.panelWorkspace.TabIndex = 0;
            // 
            // picEdit
            // 
            this.picEdit.Location = new System.Drawing.Point(0, 0);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(100, 50);
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
            // textboxTextToDraw
            // 
            this.textboxTextToDraw.Location = new System.Drawing.Point(256, 22);
            this.textboxTextToDraw.Name = "textboxTextToDraw";
            this.textboxTextToDraw.Size = new System.Drawing.Size(61, 20);
            this.textboxTextToDraw.TabIndex = 2;
            this.textboxTextToDraw.TextChanged += new System.EventHandler(this.textboxTextToDraw_TextChanged);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnColor.Location = new System.Drawing.Point(166, 19);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(24, 24);
            this.btnColor.TabIndex = 1;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // trackSize
            // 
            this.trackSize.AutoSize = false;
            this.trackSize.Location = new System.Drawing.Point(36, 19);
            this.trackSize.Maximum = 40;
            this.trackSize.Minimum = 2;
            this.trackSize.Name = "trackSize";
            this.trackSize.Size = new System.Drawing.Size(124, 24);
            this.trackSize.TabIndex = 0;
            this.trackSize.TickFrequency = 2;
            this.trackSize.Value = 2;
            this.trackSize.Scroll += new System.EventHandler(this.trackSize_Scroll);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.copyToClipboardToolStripMenuItem,
            this.uploadToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.testToolStripMenuItem.Text = "File";
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
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
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
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.undoToolStripMenuItem.Text = "Undo [Ctrl+Z]";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // resetCtrlRToolStripMenuItem
            // 
            this.resetCtrlRToolStripMenuItem.Name = "resetCtrlRToolStripMenuItem";
            this.resetCtrlRToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resetCtrlRToolStripMenuItem.Text = "Reset [Ctrl+R]";
            this.resetCtrlRToolStripMenuItem.Click += new System.EventHandler(this.resetCtrlRToolStripMenuItem_Click);
            // 
            // grpEdit
            // 
            this.grpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEdit.Controls.Add(this.btnCrop);
            this.grpEdit.Controls.Add(this.trackSize);
            this.grpEdit.Controls.Add(this.btnPen);
            this.grpEdit.Controls.Add(this.btnDone);
            this.grpEdit.Controls.Add(this.btnColor);
            this.grpEdit.Controls.Add(this.btnBlur);
            this.grpEdit.Controls.Add(this.btnText);
            this.grpEdit.Controls.Add(this.textboxTextToDraw);
            this.grpEdit.Location = new System.Drawing.Point(12, 496);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(845, 52);
            this.grpEdit.TabIndex = 7;
            this.grpEdit.TabStop = false;
            this.grpEdit.Text = "Edit";
            // 
            // btnPen
            // 
            this.btnPen.BackColor = System.Drawing.Color.Transparent;
            this.btnPen.Image = global::InfiniPad.Properties.Resources.brush_icon;
            this.btnPen.Location = new System.Drawing.Point(196, 19);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(24, 24);
            this.btnPen.TabIndex = 4;
            this.btnPen.UseVisualStyleBackColor = false;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // btnDone
            // 
            this.btnDone.Image = global::InfiniPad.Properties.Resources.check_icon;
            this.btnDone.Location = new System.Drawing.Point(6, 19);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(24, 24);
            this.btnDone.TabIndex = 5;
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnBlur
            // 
            this.btnBlur.BackColor = System.Drawing.Color.Transparent;
            this.btnBlur.Image = global::InfiniPad.Properties.Resources.blur_icon;
            this.btnBlur.Location = new System.Drawing.Point(323, 19);
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.Size = new System.Drawing.Size(24, 24);
            this.btnBlur.TabIndex = 6;
            this.btnBlur.UseVisualStyleBackColor = false;
            this.btnBlur.Click += new System.EventHandler(this.btnBlur_Click);
            // 
            // btnText
            // 
            this.btnText.Image = global::InfiniPad.Properties.Resources.text_icon;
            this.btnText.Location = new System.Drawing.Point(226, 19);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(24, 24);
            this.btnText.TabIndex = 3;
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveToolStripMenuItem.Text = "Save As";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // copyToClipboardToolStripMenuItem1
            // 
            this.copyToClipboardToolStripMenuItem1.Name = "copyToClipboardToolStripMenuItem1";
            this.copyToClipboardToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.copyToClipboardToolStripMenuItem1.Text = "Copy To Clipboard";
            this.copyToClipboardToolStripMenuItem1.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // uploadToolStripMenuItem1
            // 
            this.uploadToolStripMenuItem1.Name = "uploadToolStripMenuItem1";
            this.uploadToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.uploadToolStripMenuItem1.Text = "Upload";
            this.uploadToolStripMenuItem1.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem1.Text = "Edit";
            // 
            // undoCtrlZToolStripMenuItem
            // 
            this.undoCtrlZToolStripMenuItem.Name = "undoCtrlZToolStripMenuItem";
            this.undoCtrlZToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoCtrlZToolStripMenuItem.Text = "Undo [Ctrl+Z]";
            this.undoCtrlZToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoCtrlRToolStripMenuItem
            // 
            this.redoCtrlRToolStripMenuItem.Name = "redoCtrlRToolStripMenuItem";
            this.redoCtrlRToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redoCtrlRToolStripMenuItem.Text = "Redo [Ctrl+R]";
            this.redoCtrlRToolStripMenuItem.Click += new System.EventHandler(this.resetCtrlRToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem1,
            this.editToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.copyToClipboardToolStripMenuItem2,
            this.uploadToolStripMenuItem2});
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.testToolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem2.Text = "Save As";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // copyToClipboardToolStripMenuItem2
            // 
            this.copyToClipboardToolStripMenuItem2.Name = "copyToClipboardToolStripMenuItem2";
            this.copyToClipboardToolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.copyToClipboardToolStripMenuItem2.Text = "Copy To Clipboard";
            this.copyToClipboardToolStripMenuItem2.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // uploadToolStripMenuItem2
            // 
            this.uploadToolStripMenuItem2.Name = "uploadToolStripMenuItem2";
            this.uploadToolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.uploadToolStripMenuItem2.Text = "Upload";
            this.uploadToolStripMenuItem2.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem2
            // 
            this.editToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoCtrlZToolStripMenuItem1,
            this.resetCtrlZToolStripMenuItem});
            this.editToolStripMenuItem2.Name = "editToolStripMenuItem2";
            this.editToolStripMenuItem2.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem2.Text = "Edit";
            // 
            // undoCtrlZToolStripMenuItem1
            // 
            this.undoCtrlZToolStripMenuItem1.Name = "undoCtrlZToolStripMenuItem1";
            this.undoCtrlZToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.undoCtrlZToolStripMenuItem1.Text = "Undo [Ctrl+Z]";
            this.undoCtrlZToolStripMenuItem1.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // resetCtrlZToolStripMenuItem
            // 
            this.resetCtrlZToolStripMenuItem.Name = "resetCtrlZToolStripMenuItem";
            this.resetCtrlZToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resetCtrlZToolStripMenuItem.Text = "Reset [Ctrl+Z]";
            this.resetCtrlZToolStripMenuItem.Click += new System.EventHandler(this.resetCtrlRToolStripMenuItem_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Image = global::InfiniPad.Properties.Resources.crop_icon;
            this.btnCrop.Location = new System.Drawing.Point(353, 19);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(24, 24);
            this.btnCrop.TabIndex = 7;
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // EditorEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 560);
            this.Controls.Add(this.grpEdit);
            this.Controls.Add(this.panelWorkspace);
            this.Controls.Add(this.menuStrip1);
            this.Name = "EditorEx";
            this.Text = "EditorEx";
            this.panelWorkspace.ResumeLayout(false);
            this.panelWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSize)).EndInit();
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelWorkspace;
        private System.Windows.Forms.PictureBox picEdit;
        private System.Windows.Forms.TrackBar trackSize;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TextBox textboxTextToDraw;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetCtrlRToolStripMenuItem;
        private System.Windows.Forms.Button btnBlur;
        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem undoCtrlZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoCtrlRToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem undoCtrlZToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetCtrlZToolStripMenuItem;
        private System.Windows.Forms.Button btnCrop;
    }
}