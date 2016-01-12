using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InfiniPad
{
    public partial class editor : Form
    {
        private struct PenSize
        {
            public string Name;
            public int Size;
            public PenSize(string name, int size)
            {
                Name = name;
                Size = size;
            }
        }

        Dictionary<string, int> sizelis = new Dictionary<string, int>();
        private enum Tool
        {
            None = 1,
            Pen,
        }
        private Tool Using;
        private bool bMouseDown = false;
        private Bitmap curImg;
        private List<Bitmap> picHistory = new List<Bitmap>();
        Color penCol;
        Pen penObj;
        int penWidth;
        Point[] cursorPos = {
            new Point(0,0),
            new Point(1,1),
        };
        PenSize[] sizelist =
        {
            new PenSize("Pixel", 1),
            new PenSize("Small", 2),
            new PenSize("Normal", 5),
            new PenSize("Large", 10),
            new PenSize("Huge", 25),
        };




        public editor(Bitmap Image)
        {
            InitializeComponent();
            picEdit.Image = Image;
            curImg = Image;
            Using = Tool.Pen;
            penCol = Properties.Settings.Default.PenColor;
            penObj = new Pen(penCol, 4);
            penWidth = sizelist[2].Size;
            cmbPenSize.Text = sizelist[2].Name;
            foreach(PenSize ps in sizelist)
                cmbPenSize.Items.Add(ps.Name);
            this.Icon = Properties.Resources.icon;
            if (Properties.Settings.Default.WatermarkEnabled)
            {
                PaintHelp.applyWatermark(ref curImg);
                picEdit.Image = curImg;
            }
            bool enbld = Properties.Settings.Default.EditorEnabled;
            this.Visible = enbld;
            if (!enbld)
            {
                UploadImage();
            }

        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            cd.Color = penCol;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Using = Tool.Pen;
                penCol = cd.Color;
                refreshPen();
            }
        }

        private void picEdit_MouseDown(object sender, MouseEventArgs e)
        {
            cursorPos[0] = e.Location;
            cursorPos[1] = e.Location;
            picHistory.Add(new Bitmap(curImg));
            bMouseDown = true;
        }

        private void picEdit_MouseUp(object sender, MouseEventArgs e)
        {
            bMouseDown = false;
            GC.Collect();
        }

        private void picEdit_MouseMove(object sender, MouseEventArgs e)
        {
            cursorPos[1] = e.Location;
            picEdit.Invalidate();
            if(Using == Tool.Pen)
            {
                if (bMouseDown)
                {
                    Graphics g = Graphics.FromImage(curImg);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //still unsure whether i should use DrawEllipse or FillEllipse
                    g.FillEllipse(new SolidBrush(penObj.Color), new Rectangle(e.X, e.Y, penWidth, penWidth));
                    //smoothing, looks choppy otherwise
                    g.DrawLine(penObj, new Point(cursorPos[0].X + (penWidth / 2), cursorPos[0].Y + (penWidth/2)), new Point(cursorPos[1].X + (penWidth / 2), cursorPos[1].Y + (penWidth / 2)));
                   
                    g.Save();
                    g.Dispose();
                    cursorPos[0] = e.Location;

                    picEdit.Image = curImg;
                }
            }
        }

        private void picEdit_Paint(object sender, PaintEventArgs e)
        {
            if (Using == Tool.Pen)
            {
                e.Graphics.FillEllipse(new SolidBrush(penObj.Color), new Rectangle(cursorPos[1].X, cursorPos[1].Y, (int)penObj.Width, (int)penObj.Width));
            }
        }

        private void refreshPen()
        {
            penObj = new Pen(penCol, penWidth);
        }


        

        private void cmbPenSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(PenSize ps in sizelist)
            {
                if(cmbPenSize.Text == ps.Name)
                {
                    penWidth = ps.Size;
                    refreshPen();
                    return;
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = Upload.FileFilter;
            sfd.Title = "Save Image";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                curImg.Save(sfd.FileName);
            }
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(curImg);
        }

        private void picEdit_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void picEdit_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                undo();
                return true;
            }
            if(keyData == (Keys.Control | Keys.R))
            {
                reset();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void undo()
        {
            if (picHistory.Count > 0)
            {
                curImg = picHistory.ElementAt(picHistory.Count - 1);
                picHistory.RemoveAt(picHistory.Count - 1);
                picEdit.Image = curImg;
            }
        }

        private void reset()
        {
            while (picHistory.Count > 1)
            {
                picHistory.RemoveAt(picHistory.Count - 1);
            }
            curImg = picHistory.ElementAt(0);
            picHistory.RemoveAt(0);
            picEdit.Image = curImg;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void resetCtrlRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void UploadImage()
        {
            this.Hide();
            var PictureLink = Upload.toImgur(curImg);
            
            Main.DisplayBubbleMessage(3, "Imgur Upload Completed", "Your image is live at " + PictureLink.link + "! This link has been copied to your clipboard.");
            Clipboard.SetText(PictureLink.link.ToString());
            GC.Collect();
            this.Close();
        }

        private void HandleUpload(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void editor_Resize(object sender, EventArgs e)
        {
            picPanel.Width = this.Width-27;
            picPanel.Height = this.Height - editGroupBox.Size.Height*2;
            editGroupBox.Location =  new Point(this.editGroupBox.Location.X, this.picPanel.Location.Y+this.picPanel.Size.Height);
            editGroupBox.Width = this.Width - this.editGroupBox.Location.X*3;
        }
    }
}
