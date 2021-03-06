﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace InfiniPad
{
    public partial class PartialScreenie : Form
    {
        private Rectangle fullRect;
        private Point startP, endP;
        private Brush rectBrush     = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
        private Brush measBrush     = new SolidBrush(Properties.Settings.Default.MeasurementColor);
        private Brush outlineBrush  = new SolidBrush(Properties.Settings.Default.OutlineColor);
        private Font fntMeasure;
        private Bitmap bmpDesktop;



        public PartialScreenie()
        {
            fullRect = PaintHelp.getFullSize();
            InitializeComponent();
            this.Visible = false;
            this.Size = fullRect.Size;
            this.DoubleBuffered = true;
            this.Show();
        }

        private void ScreenshotHelper_Load(object sender, EventArgs e)
        {
            //Point topLeft = PaintHelp.GetTopLeftMonitorPoint();
            Point offsetPoint = new Point(fullRect.X, fullRect.Y);
            this.Location = offsetPoint;
            this.bmpDesktop = PaintHelp.GetScreen(offsetPoint, fullRect.Size);
            this.fntMeasure = PaintHelp.GetFont("Cambria", 48, FontStyle.Regular);
        }

        private void ScreenshotHelper_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bmpDesktop, new Point(0, 0));
            
            if (startP.IsEmpty)
            {
                g.FillRectangle(rectBrush, new Rectangle(0, 0, fullRect.Width, fullRect.Height));
            }
            else
            {
                Rectangle drawArea = PaintHelp.fixNegRect(startP, endP);
                g.DrawOutlinedRect(drawArea, outlineBrush, 3);
                g.DrawAroundRect(drawArea, new Rectangle(0, 0, fullRect.Width, fullRect.Height), rectBrush);
                g.DrawRotatedText(Math.Abs(startP.X-endP.X).ToString(), fntMeasure, measBrush, new PointF(drawArea.X, drawArea.Y+drawArea.Size.Height), 0);

                string ySize = Math.Abs(startP.Y - endP.Y).ToString();
                g.DrawRotatedText( ySize, fntMeasure, measBrush,
                    new PointF(drawArea.X-g.MeasureString(ySize, fntMeasure).Height-10, drawArea.Y+drawArea.Size.Height-g.MeasureString(ySize, fntMeasure).Width), -90);
            }
            
        }

        private void ScreenshotHelper_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Rectangle section = PaintHelp.fixNegRect(startP, endP);
                this.Visible = false;
                new EditorEx(PaintHelp.cropBitmap(bmpDesktop, section));
                this.Close();
            }
            catch (ArgumentException)
            {
                this.Close(); //This occurs when your startP and endP are the same
            }
            
        }

        private void ScreenshotHelper_MouseMove(object sender, MouseEventArgs e)
        {
            if (!startP.IsEmpty)
            {
                endP = e.Location;
                this.Refresh();
            }
                
        }

        private void ScreenshotHelper_MouseDown(object sender, MouseEventArgs e)
        {
            startP = e.Location;
        }
    }
}
