using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdAndLifeWebsite
{
	/// <summary>
	/// Summary description for ArticleImage
	/// </summary>
	public class ArticleImage : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{

			

			var articleId = int.Parse(context.Request.QueryString["a"]);
			var imageNum = int.Parse(context.Request.QueryString["n"]);

			var data = WebsiteArticle.GetImage(articleId, imageNum);

			context.Response.ContentType = "image/jpeg";
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