﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace InfiniPad
{
    static class PaintHelp
    {

        //https://stackoverflow.com/a/28923832
        #region DPI_FIX
        private enum ProcessDPIAwareness
        {
          ProcessDPIUnaware = 0,
          ProcessSystemDPIAware = 1,
          ProcessPerMonitorDPIAware = 2
        }

        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(ProcessDPIAwareness value);

        public static void FixDPIAwareness()
        {
            try
            {
                    if (Environment.OSVersion.Version.Major >= 6)
                    {
                        SetProcessDpiAwareness(ProcessDPIAwareness.ProcessPerMonitorDPIAware);
                    }
            }
            catch (EntryPointNotFoundException)//this exception occures if OS does not implement this API, just ignore it.
            {
            }
        }
        #endregion
        
        public static Font GetFont(string family, int size, FontStyle style)
        {
            return new Font(new FontFamily(family), size, style, GraphicsUnit.Pixel);
        }

        public static void DrawOutlinedRect(this Graphics g, Rectangle rect, Brush b, int thickness)
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
        public static void DrawAroundRect(this Graphics g, Rectangle inRect, Rectangle outRect, Brush b)
        {
            g.FillRectangle(b, new Rectangle(outRect.X, outRect.Y, outRect.Width, outRect.Y+inRect.Y)); //top
            g.FillRectangle(b, new Rectangle(outRect.X, outRect.Y+inRect.Y, inRect.X-outRect.X, outRect.Height-(outRect.Y + inRect.Y))); //left
            g.FillRectangle(b, new Rectangle(inRect.X, inRect.Y + inRect.Height, outRect.Width - (inRect.X - outRect.X), outRect.Height-(inRect.Y + inRect.Height))); //bottom
            g.FillRectangle(b, new Rectangle(inRect.X+inRect.Width, inRect.Y, outRect.Width-inRect.X+inRect.Width, inRect.Height)); //right
        }
        public static void DrawRotatedText(this Graphics g, string s, Font font, Brush b, PointF pt, float Angle)
        {
            SizeF len = g.MeasureString(s, font);
            float X = pt.X + ((float)len.Width / 2);
            float Y = pt.Y + ((float)len.Height / 2);
            g.TranslateTransform(X, Y);
            g.RotateTransform(Angle);
            g.TranslateTransform(-X, -Y);
            g.DrawString(s, font, b, pt);
        }

        /* https://stackoverflow.com/a/1317252 */
        public static Rectangle getFullSize()
        {
            //Rectangle rect = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);
            Rectangle rect = new Rectangle(0, 0, 0, 0);
            foreach (Screen screen in Screen.AllScreens)
                rect = Rectangle.Union(rect, screen.Bounds);
            return rect;
        }

        public static Bitmap GetScreen(Point p, Size s)
        {
            Bitmap b = new Bitmap(s.Width, s.Height);
            Graphics g = Graphics.FromImage(b);
            g.CopyFromScreen(p.X, p.Y, 0, 0, s, CopyPixelOperation.SourceCopy);

            return b;
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

        public static Bitmap cropBitmap(Bitmap bmp, Rectangle newRegion)
        {
            Bitmap bmpResult = new Bitmap(newRegion.Width, newRegion.Height);
            Graphics g = Graphics.FromImage(bmpResult);
            g.DrawImage(bmp, 0, 0, newRegion, GraphicsUnit.Pixel);
            g.Dispose();
            return bmpResult;

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
            if (width == 0 || height == 0)
                return bmp;
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

        public static void Blur(this Bitmap bmp, Rectangle region, int pixSize)
        {
            if (region.Width == 0 || region.Height == 0)
                return;
            if (pixSize == 0)
                pixSize = 2;
            Bitmap small = new Bitmap(region.Width, region.Height);
            Graphics smallg = Graphics.FromImage(small);
            smallg.DrawImage(bmp, 0, 0, region, GraphicsUnit.Pixel);

            //start edit small

            int pixelsOnWidth = small.Width / pixSize;
            int pixelsOnHeight = small.Height / pixSize;
            for(int w = 1; w <= pixelsOnWidth; w++)
            {
                int wide = pixelsOnWidth == w ? pixSize + (small.Width % pixSize) : pixSize;
                for(int h = 1; h <= pixelsOnHeight; h++)
                {
                    int height = pixelsOnHeight == h ? pixSize + (small.Height % pixSize) : pixSize;
                    int Xbase = pixSize * (w - 1);
                    int Ybase = pixSize * (h - 1);
                    int r, b, g;
                    r = b = g = 0;
                    int pixelCount = 0;
                    for (int x = Xbase; x < Xbase + wide; x++)
                    {
                        for(int y = Ybase; y < Ybase + height; y++)
                        {
                            Color pixCol = small.GetPixel(x, y);
                            r += pixCol.R;
                            b += pixCol.B;
                            g += pixCol.G;
                            pixelCount++;
                        }
                    }
                    if (pixelCount == 0)
                    {
                        continue;
                    }
                    Color avgCol = Color.FromArgb(255, r / pixelCount, g / pixelCount, b / pixelCount);
                    smallg.FillRectangle(new SolidBrush(avgCol), Xbase, Ybase, wide, height);
                }

            }
            //end edit small
            smallg.Dispose();
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.DrawImage(small, region.X, region.Y);
            gfx.Dispose();
        }

        public static void applyWatermark(ref Bitmap bmp)
        {
            Bitmap watermark = getWatermark();
            float scale;
            for(scale = 1 ;scale > 0; scale-=0.01f)
            {
                float heightRatio = (float)watermark.Height*scale / bmp.Height;
                float widthRatio = (float)watermark.Width*scale / bmp.Width;
                float allowedRatio = Properties.Settings.Default.WatermarkScale;
                if (heightRatio <= allowedRatio && widthRatio <= allowedRatio)
                    break;
            }
            if (scale <= 0)
                return;


            

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
 
 