﻿namespace InfiniPad
{
    partial class PartialScreenie
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
            this.SuspendLayout();
            // 
            // PartialScreenie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PartialScreenie";
            this.Text = "ScreenshotHelper";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ScreenshotHelper_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScreenshotHelper_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenshotHelper_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenshotHelper_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScreenshotHelper_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}