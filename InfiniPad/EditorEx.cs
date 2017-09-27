using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace InfiniPad
{
    public partial class EditorEx : Form
    {

        private abstract class ToolFunc
        {
            public Tool tool;
            protected EditorEx inst;
            public ToolFunc(EditorEx inst, Tool t)
            {
                this.inst = inst;
                this.tool = t;
            }
            public abstract void MouseDown(object sender, MouseEventArgs e);
            public abstract void MouseUp(object sender, MouseEventArgs e);
            public abstract void Paint(object sender, PaintEventArgs e);
            public abstract void MouseMove(object sender, MouseEventArgs e);
        }

        private enum Tool
        {
            Pen,
            Text,
            Blur,
            Crop,
            Highlighter,
        }

        Point cursorLastPos;
        Tool toolInUse;
        string textToDraw;
        Bitmap curImg;
        Pen penObj;
        bool bMouseDown;
        List<ToolFunc> funcList = new List<ToolFunc>();
        public EditorEx(Bitmap Image)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon;

            curImg                      = Image;
            picEdit.Image               = curImg;
            toolInUse                   = Tool.Pen;
            trackSize.Value             = 6;
            penObj                      = new Pen(Properties.Settings.Default.PenColor, trackSize.Value);
            textToDraw                  = Properties.Settings.Default.TextDefault;
            textboxTextToDraw.Text      = textToDraw;
            cursorLastPos               = new Point();
            bMouseDown                  = false;

            btnColor.BackColor          = penObj.Color;

            if (Properties.Settings.Default.WatermarkEnabled)
            {
                PaintHelp.applyWatermark(ref curImg);
                picEdit.Image = curImg;
            }
            if (!Properties.Settings.Default.EditorEnabled)
            {
                UploadImage();
            }
            else if (!this.Visible)
            {
                this.Show();
            }

            funcList.Add(new tPen(this, Tool.Pen));
            funcList.Add(new tBlur(this, Tool.Blur));
            funcList.Add(new tCrop(this, Tool.Crop));
            funcList.Add(new tText(this, Tool.Text));
            funcList.Add(new tHighlighter(this, Tool.Highlighter));

        }


        private void btnText_Click(object sender, EventArgs e)
        {
            toolInUse = Tool.Text;
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            toolInUse = Tool.Pen;
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            toolInUse = Tool.Blur;

        }
        private void btnCrop_Click(object sender, EventArgs e)
        {
            toolInUse = Tool.Crop;
        }
        private void btnHighlighter_Click(object sender, EventArgs e)
        {
            toolInUse = Tool.Highlighter;
        }

        #region Highlighter
        private class tHighlighter : ToolFunc
        {
            public tHighlighter(EditorEx inst, Tool t) : base(inst, t) { }
            public override void MouseDown(object sender, MouseEventArgs e)
            {
                inst.cursorLastPos = inst.getPointOnImage();
            }
            public override void MouseMove(object sender, MouseEventArgs e)
            {
                if (!inst.bMouseDown)
                    return;
                Graphics g = Graphics.FromImage(inst.curImg);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                int opacity = Properties.Settings.Default.HighlighterOpacity;
                inst.paintHighlighter(g, opacity, true);
                g.Dispose();
                inst.cursorLastPos = e.Location;
                inst.picEdit.Image = inst.curImg;
            }
            public override void MouseUp(object sender, MouseEventArgs e)
            {
                //NONE
            }
            public override void Paint(object sender, PaintEventArgs e)
            {
                inst.paintHighlighter(e.Graphics, 255);
            }
        }
        #endregion
        #region Crop
        private class tCrop : ToolFunc
        {
            public tCrop(EditorEx inst, Tool t) : base(inst, t) { }
            public override void MouseDown(object sender, MouseEventArgs e)
            {
                inst.cursorLastPos = e.Location;
            }
            public override void MouseMove(object sender, MouseEventArgs e)
            {
            }
            public override void MouseUp(object sender, MouseEventArgs e)
            {
                Rectangle region = PaintHelp.fixNegRect(inst.cursorLastPos, e.Location);
                inst.curImg = PaintHelp.cropBitmap(inst.curImg, region);
                inst.picEdit.Image = inst.curImg;
            }
            public override void Paint(object sender, PaintEventArgs e)
            {
                inst.paintCrossCursor(e.Graphics);
                if (inst.bMouseDown)
                    e.Graphics.DrawAroundRect(PaintHelp.fixNegRect(inst.cursorLastPos, inst.getPointOnImage()), new Rectangle(0, 0, inst.curImg.Width, inst.curImg.Height), new SolidBrush(Color.FromArgb(128, 0, 0, 0)));
            }
        }
        #endregion
        #region Blur
        private class tBlur : ToolFunc
        {
            public tBlur(EditorEx inst, Tool t) : base(inst, t) { }
            public override void MouseDown(object sender, MouseEventArgs e)
            {
                inst.cursorLastPos = e.Location;
            }
            public override void MouseMove(object sender, MouseEventArgs e)
            {
                //NONE
            }
            public override void MouseUp(object sender, MouseEventArgs e)
            {
                Rectangle region = PaintHelp.fixNegRect(inst.cursorLastPos, e.Location);
                inst.curImg.Blur(region, inst.trackSize.Value / 2);
                inst.picEdit.Image = inst.curImg;
            }
            public override void Paint(object sender, PaintEventArgs e)
            {
                inst.paintCrossCursor(e.Graphics);
                if (inst.bMouseDown)
                    e.Graphics.DrawOutlinedRect(PaintHelp.fixNegRect(inst.cursorLastPos, inst.getPointOnImage()), Brushes.Blue, 2);
            }
        }
        #endregion
        #region Text
        private void textboxTextToDraw_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textboxTextToDraw.Text))
                return;
            textToDraw = textboxTextToDraw.Text;
        }
        private class tText : ToolFunc
        {
            public tText(EditorEx inst, Tool t) : base(inst, t) { }
            public override void MouseDown(object sender, MouseEventArgs e)
            {
                Graphics g = Graphics.FromImage(inst.curImg);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                inst.paintText(g);
                g.Save();
                g.Dispose();
                inst.picEdit.Image = inst.curImg;
            }
            public override void MouseMove(object sender, MouseEventArgs e)
            {
                //NONE
            }
            public override void MouseUp(object sender, MouseEventArgs e)
            {
                //NONE
            }
            public override void Paint(object sender, PaintEventArgs e)
            {
                inst.paintText(e.Graphics);
            }
        }
        #endregion
        #region Pen
        private class tPen : ToolFunc
        {
            public tPen(EditorEx inst, Tool t) : base(inst, t) { }
            public override void MouseDown(object sender, MouseEventArgs e)
            {
                inst.cursorLastPos = inst.getPointOnImage();
            }
            public override void MouseMove(object sender, MouseEventArgs e)
            {
                if (!inst.bMouseDown)
                    return;
                Point curPos = e.Location;
                Graphics g = Graphics.FromImage(inst.curImg);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                inst.paintPen(g);
                var cursorLastPos = inst.cursorLastPos;
                g.DrawLine(inst.penObj, new Point(cursorLastPos.X + (int)inst.penObj.Width / 2, cursorLastPos.Y + (int)inst.penObj.Width / 2),
                    new Point(curPos.X + (int)inst.penObj.Width / 2, curPos.Y + (int)inst.penObj.Width / 2));
                inst.cursorLastPos = curPos;
                g.Save();
                g.Dispose();
                inst.picEdit.Image = inst.curImg;
            }
            public override void MouseUp(object sender, MouseEventArgs e)
            {
                //NONE
            }
            public override void Paint(object sender, PaintEventArgs e)
            {
                inst.paintPen(e.Graphics);
            }
        }
        #endregion



        private void picEdit_MouseEnter(object sender, EventArgs e) { Cursor.Hide();}
        private void picEdit_MouseLeave(object sender, EventArgs e) { Cursor.Show(); GC.Collect(); }
        private void picEdit_MouseDown(object sender, MouseEventArgs e) {
            bMouseDown = true;
            AddToHistory(curImg);
            foreach(ToolFunc func in funcList)
            {
                if (func.tool == toolInUse)
                    func.MouseDown(sender, e);
            }
        }
        private void picEdit_MouseUp(object sender, MouseEventArgs e) {
            bMouseDown = false;
            foreach (ToolFunc func in funcList)
            {
                if (func.tool == toolInUse)
                    func.MouseUp(sender, e);
            }
            GC.Collect();
        }

        private void picEdit_Paint(object sender, PaintEventArgs e)
        {
            foreach (ToolFunc func in funcList)
            {
                if (func.tool == toolInUse)
                    func.Paint(sender, e);
            }
        }

        private void picEdit_MouseMove(object sender, MouseEventArgs e)
        {
            picEdit.Invalidate();
            foreach (ToolFunc func in funcList)
            {
                if (func.tool == toolInUse)
                    func.MouseMove(sender, e);
            }
        }

        private Point getPointOnImage()
        {
            return picEdit.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
        }
        private void paintPen(Graphics g)
        {
            Point cur = getPointOnImage();
            g.FillEllipse(new SolidBrush(penObj.Color), new Rectangle(cur.X,cur.Y, (int)penObj.Width, (int)penObj.Width));
        }

        private void paintText(Graphics g)
        {
            Point cur = getPointOnImage();
            g.DrawString(textToDraw, new Font("Arial", penObj.Width + 8), new SolidBrush(penObj.Color), new PointF(cur.X, cur.Y));
        }

        private void paintHighlighter(Graphics g, int opacity, bool isRect = false)
        {
            Point curPoint = getPointOnImage();
            Pen tempPen = new Pen(Color.FromArgb(opacity, penObj.Color), 3);
            
            if (isRect)
                g.FillRectangle(new SolidBrush(tempPen.Color), PaintHelp.fixNegRect(new Point(curPoint.X,curPoint.Y-trackSize.Value), new Point(cursorLastPos.X, curPoint.Y+trackSize.Value)));
            else
                g.DrawLine(tempPen, new Point(curPoint.X, curPoint.Y + trackSize.Value), new Point(curPoint.X, curPoint.Y - trackSize.Value));
        }

        private void paintCrossCursor(Graphics g)
        {
            int size = 10;
            Point cur = getPointOnImage();
            g.DrawLine(new Pen(Color.Gray, 2), new Point(cur.X + size, cur.Y), new Point(cur.X - size, cur.Y));
            g.DrawLine(new Pen(Color.Gray, 2), new Point(cur.X , cur.Y+size), new Point(cur.X, cur.Y-size));
        }


        private void trackSize_Scroll(object sender, EventArgs e)
        {
            penObj.Width = trackSize.Value;
        }



        private void btnColor_Click(object sender, EventArgs e)
        {
            Color res = Globals.requestColorDialog(btnColor);
            if (res != Color.Empty)
            {
                penObj.Color = res;
                btnColor.BackColor = res;
            }
        }


        private void btnDone_Click(object sender, EventArgs e)
        {
            UploadImage();
        }


        #region Undo/Redo
        List<Bitmap> ImageHistory = new List<Bitmap>();
        private void AddToHistory(Bitmap b) { ImageHistory.Add(new Bitmap(b)); }
        private void undo()
        {
            if (ImageHistory.Count > 0)
            {
                curImg = ImageHistory.ElementAt(ImageHistory.Count - 1);
                ImageHistory.RemoveAt(ImageHistory.Count - 1);
                picEdit.Image = curImg;
            }
        }

        private void reset()
        {
            if (ImageHistory.Count == 0)
                return;
            while (ImageHistory.Count > 1)
            {
                ImageHistory.RemoveAt(ImageHistory.Count - 1);
            }
            curImg = ImageHistory.ElementAt(0);
            ImageHistory.RemoveAt(0);
            picEdit.Image = curImg;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                undo();
                return true;
            }
            if (keyData == (Keys.Control | Keys.R))
            {
                reset();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        #region Upload
        private void UploadImage() {
            Thread t = new Thread(new ThreadStart(_UploadImage));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }


        private void _UploadImage()
        {
            try
            {
                this.InvokeIfRequired(() =>
                {
                    while (this.Handle == null)
                        Application.DoEvents();
                    this.Hide();
                });

                Imgur.ImageInfo PictureLink = new Imgur.ImageInfo();
                PictureLink.success = false;

                bool bShouldRetry = Properties.Settings.Default.ShouldRetryUpload;
                int numTries = Properties.Settings.Default.ShouldRetryUpload ? Properties.Settings.Default.NumRetries+1 : 1;

                for (int i = 1; i <= numTries && !PictureLink.success; i++)
                    PictureLink = Imgur.toImgur(curImg);

                if (PictureLink.success)
                {
                    bool shouldClipboard = Properties.Settings.Default.ClipboardOnUpload;
                    Notification.DisplayBubbleMessage(3, "Imgur Upload Completed", "Your image is live at " + PictureLink.link + "!" + (shouldClipboard ? " This link has been copied to your clipboard." : ""));
                    if (shouldClipboard)
                        Clipboard.SetText(PictureLink.link.ToString());
                    GC.Collect();
                    Globals.getMainForm().addImgurItem(PictureLink.link, PictureLink.deletehash);
                    curImg.Dispose();
                }
                else
                {
                    Globals.ErrorLog("Imgur.toImgur() failed : " + PictureLink.ex.Message, true);
                }

                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
            }
            catch (Exception ex)
            {
                Globals.ErrorLog("_UploadImage() Failed: " + ex.Message, false);
            }

        }

        #endregion
        #region Tool Strip

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = Imgur.FileFilter;
            sfd.Title = "Save Image";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                curImg.Save(sfd.FileName);
            }
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e) { Clipboard.SetImage(curImg); }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void resetCtrlRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset();
        }

        #endregion

       
    }
}