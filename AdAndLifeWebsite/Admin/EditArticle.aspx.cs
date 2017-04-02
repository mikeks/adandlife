using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite.Admin
{
	public partial class EditArticle : System.Web.UI.Page
	{

		public string ArtText;

		protected void Page_Load(object sender, EventArgs e)
		{

			int id = 0;
			try
			{
				id = int.Parse(Request["id"]);

			}
			catch 
			{
			}

			WebsiteArticle art;

			if (id > 0)
			{
				art = WebsiteArticle.GetById(id);
			} else
			{
				art = new WebsiteArticle();
			}


			if (IsPostBack)
			{
				art.Txt = ArticleText.InnerHtml;
				art.Name = ArticleName.Text;
				art.Save();

				Response.Redirect("~/Admin/ArticleList.aspx");

			}

			ArticleText.InnerHtml = art.Txt;
			ArticleName.Text = art.Name;


		}
	}
}