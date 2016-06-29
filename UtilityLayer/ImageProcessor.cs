using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace UtilityLayer
{
    public class ImageProcessor
    {
        #region Generate Thumbnail Image
        public static System.Drawing.Image CreateThumbnail(System.Drawing.Image src, int widths, int heights)
        {
            Bitmap bitmap;
            int w = src.Width;
            int h = src.Height;
            int height = heights;
            int width = widths;
            if (src.Width <= widths)
            {
                width = src.Width;
            }
            int newHeight = src.Height * width / src.Width;
            if (newHeight > height) // Height resize if necessary
            {
                width = src.Width * height / src.Height;
                newHeight = height;
            }

            bitmap = new Bitmap(width, newHeight);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(src, 0, 0, bitmap.Width, bitmap.Height);
            }



            return bitmap;

        }

        #endregion



        #region Generate Thumbnail Image Width wise
        public static System.Drawing.Image CreateThumbnailWidthwise(System.Drawing.Image src, int widths)
        {
            Bitmap bitmap;
            int w = src.Width;
            int h = src.Height;
            //int height = heights;
            int width = widths;
            
            int newHeight = 0;
            double Factor = Convert.ToDouble(h) / w;
            if (w > width)
            {
                //width = width;
                newHeight = Convert.ToInt32(width * Factor);

            }
            else
            {
                width = w;
                newHeight = Convert.ToInt32(width * Factor);

            }




            bitmap = new Bitmap(width, newHeight);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(src, 0, 0, bitmap.Width, bitmap.Height);
            }



            return bitmap;

        }

        #endregion




        #region Generate Thumbnail Image Height wise
        public static System.Drawing.Image CreateThumbnailHeightwise(System.Drawing.Image src, int heights)
        {
            Bitmap bitmap;
            int w = src.Width;
            int h = src.Height;
            int height = heights;
            //int width = widths;

            int newWidth = 0;
            double Factor = Convert.ToDouble(w) / h;
            if (h > height)
            {
                //height = height;
                newWidth = Convert.ToInt32(height * Factor);

            }
            else
            {
                height = h;
                newWidth = Convert.ToInt32(height * Factor);

            }




            bitmap = new Bitmap(newWidth, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(src, 0, 0, bitmap.Width, bitmap.Height);
            }



            return bitmap;

        }

        #endregion




       




    }
}
