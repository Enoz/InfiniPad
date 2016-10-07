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

        private enum Tool
        {
            Pen,
            Text,
            Blur,
        }

        Point cursorLastPos;
        Tool toolInUse;
        string textToDraw;
        Bitmap curImg;
        Pen penObj;
        bool bMouseDown;
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


        }


        private void picEdit_MouseEnter(object sender, EventArgs e) { Cursor.Hide();}
        private void picEdit_MouseLeave(object sender, EventArgs e) { Cursor.Show(); GC.Collect(); }
        private void picEdit_MouseDown(object sender, MouseEventArgs e) {
            bMouseDown = true;
            AddToHistory(curImg);
            if(toolInUse == Tool.Pen)
            {
                cursorLastPos = getPointOnImage();
            }
            if (toolInUse == Tool.Text)
            {
                Graphics g = Graphics.FromImage(curImg);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                paintText(g);
                g.Save();
                g.Dispose();
                picEdit.Image = curImg;
            }
            if (toolInUse == Tool.Blur)
            {
                cursorLastPos = getPointOnImage();
            }
        }
        private void picEdit_MouseUp(object sender, MouseEventArgs e) {
            bMouseDown = false;
            if(toolInUse == Tool.Blur)
            {
                Rectangle region = PaintHelp.fixNegRect(cursorLastPos, getPointOnImage());
                curImg.Blur(region, trackSize.Value/2);
                picEdit.Image = curImg;
            }
            GC.Collect();
        }

        private void picEdit_Paint(object sender, PaintEventArgs e)
        {
            if(toolInUse == Tool.Pen)
            {
                paintPen(e.Graphics);
            }
            else if(toolInUse == Tool.Text)
            {
                paintText(e.Graphics);
            }
            else if(toolInUse == Tool.Blur)
            {
                paintCrossCursor(e.Graphics);
                if(bMouseDown)
                    e.Graphics.DrawOutlinedRect(PaintHelp.fixNegRect(cursorLastPos, getPointOnImage()), Brushes.Blue, 2);
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

        private void paintCrossCursor(Graphics g)
        {
            int size = 10;
            Point cur = getPointOnImage();
            g.DrawLine(new Pen(Color.Gray, 2), new Point(cur.X + size, cur.Y), new Point(cur.X - size, cur.Y));
            g.DrawLine(new Pen(Color.Gray, 2), new Point(cur.X , cur.Y+size), new Point(cur.X, cur.Y-size));
        }

        private void picEdit_MouseMove(object sender, MouseEventArgs e)
        {
            picEdit.Invalidate();
            if(toolInUse == Tool.Pen && bMouseDown)
            {
                Point curPos = getPointOnImage();
                Graphics g = Graphics.FromImage(curImg);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                paintPen(g);
                g.DrawLine(penObj, new Point(cursorLastPos.X + (int)penObj.Width / 2, cursorLastPos.Y + (int)penObj.Width / 2),
                    new Point(curPos.X + (int)penObj.Width / 2, curPos.Y + (int)penObj.Width / 2));
                cursorLastPos = curPos;
                g.Save();
                g.Dispose();
                picEdit.Image = curImg;
            }
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

        private void textboxTextToDraw_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textboxTextToDraw.Text))
                return;
            textToDraw = textboxTextToDraw.Text;
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
                var PictureLink = Imgur.toImgur(curImg);
                if (PictureLink.success)
                {
                    bool shouldClipboard = Properties.Settings.Default.ClipboardOnUpload;
                    Main.DisplayBubbleMessage(3, "Imgur Upload Completed", "Your image is live at " + PictureLink.link + "!" + (shouldClipboard ? " This link has been copied to your clipboard." : ""));
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
