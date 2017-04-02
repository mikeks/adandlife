using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite.Admin
{
	public partial class ArticleList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			ArticlesRepeater.DataSource = WebsiteArticle.All;
			ArticlesRepeater.DataBind();
		}
	}
}