using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite.Admin
{
	public partial class EditArticle : System.Web.UI.Page
	{

        public WebsiteArticle Article;
        public string ErrorMessage = "";
		public bool IsSaved = false;

		protected void Page_Load(object sender, EventArgs e)
		{
			SiteUser.CheckPageAccess("edit");

			int id = 0;
			try
			{
				id = int.Parse(Request["id"]);

			}
			catch 
			{
			}

			

			if (id > 0)
			{
				Article = WebsiteArticle.GetById(id);
			} else
			{
				Article = new WebsiteArticle();
			}


			if (IsPostBack)
			{
				Article.Txt = HttpUtility.HtmlDecode(ArticleText.InnerHtml);
				Article.Name = ArticleName.Text;

				if (FileUpload1.HasFiles)
				{
					var fn = FileUpload1.FileName;
					var ext = Path.GetExtension(fn).ToLowerInvariant();
					if (ext != ".png" && ext != ".jpg")
					{
						ErrorMessage = "Картинка не загружена. Требуется формат PNG или JPG.";
						return;
					}
                    try
                    {
                        Article.SaveImage(FileUpload1.FileBytes);
                    }
                    catch (Exception ee)
                    {
                        ErrorMessage = "Картинка не загружена. " + ee.Message;
                        return;
                    }
                }

                Article.Save();

                IsSaved = true;
				//Response.Redirect("~/Admin/ArticleList.aspx");

			}

			ArticleText.InnerHtml = Article.Txt;
			ArticleName.Text = Article.Name;


		}
	}
}