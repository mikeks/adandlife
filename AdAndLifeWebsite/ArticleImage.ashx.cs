using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;

namespace AdAndLifeWebsite
{
	/// <summary>
	/// Summary description for ArticleImage
	/// </summary>
	public class ArticleImage : IHttpHandler
	{

		private Bitmap ResizeImage(Bitmap image, int width, int height)
		{
			Bitmap img = new Bitmap(width, height);
			Graphics g = Graphics.FromImage(img);
			g.InterpolationMode = InterpolationMode.High;
			g.DrawImage(image, 0, 0, width, height);
			return img;
		}


		public void ProcessRequest(HttpContext context)
		{

			

			var articleId = int.Parse(context.Request.QueryString["a"]);
			var imageNum = int.Parse(context.Request.QueryString["n"]);

			var data = WebsiteArticle.GetImage(articleId, imageNum);

			var desiredWidth = context.Request.QueryString["th"];
			if (desiredWidth == "1")
			{
				const int thumbWidth = 100;
				Bitmap bitmap;
				using (var stream = new MemoryStream())
				{
					stream.Write(data, 0, data.Length);
					data = stream.ToArray();
					bitmap = new Bitmap(stream);
				}

				var thumb = ResizeImage(bitmap, thumbWidth, bitmap.Height * thumbWidth / bitmap.Width);

				using (var stream = new MemoryStream())
				{
					thumb.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
					data = stream.ToArray();
				}
			}

			context.Response.ContentType = "image/jpeg";
			context.Response.Cache.SetCacheability(HttpCacheability.Public);
			context.Response.Cache.SetExpires(DateTime.Now.AddHours(4));
			context.Response.Cache.SetMaxAge(new TimeSpan(4, 0, 0));
			//context.Response.AddHeader("Last-Modified", currentDocument.LastUpdated.ToLongDateString());

			context.Response.OutputStream.Write(data, 0, data.Length);

			context.Response.End();

		}

		public bool IsReusable
		{
			get
			{
				return true;
			}
		}
	}
}