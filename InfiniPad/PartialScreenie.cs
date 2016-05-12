using System;
using System.Drawing;
using System.Windows.Forms;

namespace InfiniPad
{
    public partial class PartialScreenie : Form
    {
        private Size fullSize;
        private Point startP, endP;
        private Brush rectBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
        private Brush measBrush = new SolidBrush(Color.FromArgb(255, 0, 255, 128));
        private Font fntMeasure;
        private Bitmap bmpDesktop;



        public PartialScreenie()
        {
            fullSize = PaintHelp.getFullSize();
            InitializeComponent();
            this.Visible = false;
            this.Size = fullSize;
            this.DoubleBuffered = true;
            this.Show();
        }

        private void ScreenshotHelper_Load(object sender, EventArgs e)
        {
            Point offsetPoint = new Point(0, PaintHelp.getYOffset());
            this.Location = offsetPoint;
            this.bmpDesktop = PaintHelp.GetScreen(offsetPoint, fullSize);
            this.fntMeasure = PaintHelp.GetFont("Cambria", 45, FontStyle.Regular);
        }

        private void ScreenshotHelper_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bmpDesktop, new Point(0, 0));
            
            if (startP.IsEmpty)
            {
                g.FillRectangle(rectBrush, new Rectangle(0, 0, fullSize.Width, fullSize.Height));
            }
            else
            {
                Rectangle drawArea = PaintHelp.fixNegRect(startP, endP);
                PaintHelp.DrawOutlinedRect(g, drawArea, new SolidBrush(Color.Red), 2);
                PaintHelp.DrawAroundRect(g, drawArea, new Rectangle(0, 0, fullSize.Width, fullSize.Height), rectBrush);
                PaintHelp.DrawRotatedText(g, Math.Abs(startP.X-endP.X).ToString(), fntMeasure, new SolidBrush(Color.Aquamarine), new PointF(drawArea.X, drawArea.Y+drawArea.Size.Height), 0);

                string ySize = Math.Abs(startP.Y - endP.Y).ToString();
                PaintHelp.DrawRotatedText(g, ySize, fntMeasure, new SolidBrush(Color.Aquamarine),
                    new PointF(drawArea.X-g.MeasureString(ySize, fntMeasure).Height-10, drawArea.Y+drawArea.Size.Height-g.MeasureString(ySize, fntMeasure).Width), -90);
            }
            
        }

        private void ScreenshotHelper_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Rectangle section = PaintHelp.fixNegRect(startP, endP);
                Bitmap bmpResult = new Bitmap(section.Width, section.Height);
                Graphics g = Graphics.FromImage(bmpResult);
                g.DrawImage(bmpDesktop, 0, 0, section, GraphicsUnit.Pixel);
                g.Dispose();
                this.Visible = false;
                new editor(bmpResult);
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
