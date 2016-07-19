using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace InfiniPad
{
    static class PaintHelp
    {
        
        public static Font GetFont(string family, int size, FontStyle style)
        {
            return new Font(new FontFamily(family), size, style, GraphicsUnit.Pixel);
        }

        public static void DrawOutlinedRect(Graphics g, Rectangle rect, Brush b, int thickness)
        {
            g.FillRectangle(b, new Rectangle(rect.X - thickness, rect.Y, thickness, rect.Height)); //left
            g.FillRectangle(b, new Rectangle(rect.X - thickness, rect.Y + rect.Height, //bottom
                rect.Width + (thickness * 2), thickness));
            g.FillRectangle(b, new Rectangle(rect.X + rect.Width, rect.Y, thickness, rect.Height)); //right
            g.FillRectangle(b, new Rectangle(rect.X - thickness, rect.Y -thickness, //bottom
                rect.Width + (thickness * 2), thickness));
        }

        public static Rectangle fixNegRect(Point p1, Point p2)
        {
            Size sz = new Size(Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
            Point start = new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
            return new Rectangle(start, sz);
        }
        public static void DrawAroundRect(Graphics g, Rectangle inRect, Rectangle outRect, Brush b)
        {
            g.FillRectangle(b, new Rectangle(outRect.X, outRect.Y, outRect.Width, outRect.Y+inRect.Y)); //top
            g.FillRectangle(b, new Rectangle(outRect.X, outRect.Y+inRect.Y, inRect.X-outRect.X, outRect.Height-(outRect.Y + inRect.Y))); //left
            g.FillRectangle(b, new Rectangle(inRect.X, inRect.Y + inRect.Height, outRect.Width - (inRect.X - outRect.X), outRect.Height-(inRect.Y + inRect.Height))); //bottom
            g.FillRectangle(b, new Rectangle(inRect.X+inRect.Width, inRect.Y, outRect.Width-inRect.X+inRect.Width, inRect.Height)); //right
        }
        public static void DrawRotatedText(Graphics g, string s, Font font, Brush b, PointF pt, float Angle)
        {
            SizeF len = g.MeasureString(s, font);
            float X = pt.X + ((float)len.Width / 2);
            float Y = pt.Y + ((float)len.Height / 2);
            g.TranslateTransform(X, Y);
            g.RotateTransform(Angle);
            g.TranslateTransform(-X, -Y);
            g.DrawString(s, font, b, pt);
        }
        public static Size getFullSize()
        {
            Size res = new Size();
            foreach (Screen scr in Screen.AllScreens)
            {
                res.Width += scr.Bounds.Width;
                res.Height = Math.Max(scr.Bounds.Height, res.Height);
            }
            return res;
        }

        public static Bitmap GetScreen(Point p, Size s)
        {
            Bitmap b = new Bitmap(s.Width, s.Height);
            Graphics g = Graphics.FromImage(b);
            g.CopyFromScreen(p.X, p.Y, 0, 0, s, CopyPixelOperation.SourceCopy);

            return b;
        }

        public static int getYOffset()
        {
            int lowest = Screen.PrimaryScreen.Bounds.Size.Height;
            foreach (Screen scr in Screen.AllScreens)
            {
                lowest = Math.Min(scr.Bounds.Size.Height, lowest);
            }
            return lowest - getFullSize().Height;
        }

        public static Screen getCursorScreen()
        {
            Point cursorPos = Cursor.Position;
            foreach (Screen scr in Screen.AllScreens)
            {
                if (cursorPos.X - scr.Bounds.X > 0)
                {
                    if (scr.Bounds.X + scr.Bounds.Width - cursorPos.X > 0)
                        return scr;
                }
            }
            return Screen.PrimaryScreen;
        }

        public static Bitmap setOpacity(Bitmap bmp, float opacity)
        {
            
            try
            {
                Bitmap res = new Bitmap(bmp.Width, bmp.Height);
                using (Graphics gfx = Graphics.FromImage(res))
                {
                    ColorMatrix matrix = new ColorMatrix();
                    matrix.Matrix33 = opacity;
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    gfx.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
                    gfx.Dispose();
                    return res;
                }
            }
            catch (Exception)
            {
                return bmp;
            }
        }

        public static Bitmap getWatermark()
        {
            try
            {
                return new Bitmap(Image.FromFile(Properties.Settings.Default.WatermarkPath, true));
            }
            catch (Exception)
            {
                return new Bitmap(2,2); //return blank, transparent image
            }
        }

        public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destBmp = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(destBmp))
            {
                gfx.CompositingMode = CompositingMode.SourceCopy;
                gfx.CompositingQuality = CompositingQuality.HighQuality;
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.SmoothingMode = SmoothingMode.HighQuality;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.Tile);
                    gfx.DrawImage(bmp, destRect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destBmp;

            
        }

        public static void applyWatermark(ref Bitmap bmp)
        {
            Bitmap watermark = getWatermark();
            /*int waterScale = watermark.Width < watermark.Height ? watermark.Width : watermark.Height;
            int bmpScale = bmp.Width < bmp.Height ? bmp.Width : bmp.Height;
            float scale = 1f - ((float)waterScale / (float)bmpScale);
            if (scale < 0)
                scale = 0.01f;
            if (scale > 1)
                scale = 1f;*/
            //Properties.Settings.Default.WatermarkScale
            int waterScale = watermark.Width * watermark.Height;
            int bmpScale = bmp.Width * bmp.Height;

            float scale = (bmpScale * Properties.Settings.Default.WatermarkScale) / waterScale;

            

            Bitmap resized = ResizeBitmap(watermark, (int)(watermark.Width * scale), (int)(watermark.Height * scale));
            resized = setOpacity(resized, Properties.Settings.Default.WatermarkOpacity);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingMode = CompositingMode.SourceOver;
                int margin = 5;
                int x = margin;
                int y = bmp.Height - resized.Height - margin;
                g.DrawImage(resized, new Point(x, y));
                g.Save();
                g.Dispose();
            }

        }

    }
}