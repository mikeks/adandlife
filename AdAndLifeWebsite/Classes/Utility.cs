using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace AdAndLifeWebsite.Classes
{
    public class Utility
    {

        public static string DomainPA => IsProd ? "adandlife.com" : "adandlife-test.com";
        public static string DomainBaltimore => IsProd ? "baltimore.adandlife.com" : "baltimore.adandlife-test.com";
        public static bool IsBaltimore => HttpContext.Current.Request.Url.Host.Contains("baltimore");

        public static bool IsProd => !HttpContext.Current.IsDebuggingEnabled;

        public static Bitmap ResizeImage(Image image, int width)
        {
            int height = image.Height * width / image.Width;
            return ResizeImage(image, width, height);
        }

        public static string PayPalServer => ConfigurationManager.AppSettings["PayPalServer"];
        public static string PayPalButtonCode => ConfigurationManager.AppSettings["PayPalButtonCode"];

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var gr = Graphics.FromImage(destImage))
            {
                gr.CompositingMode = CompositingMode.SourceCopy;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    gr.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }

            }

            return destImage;

        }


        public static string GetHtmlEmbeddedImg(byte[] data)
        {
            if (data == null)
                return null;

            dynamic s = Convert.ToBase64String(data);
            return "data:image/jpeg;base64," + s;

        }


    }
}