using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class article : System.Web.UI.Page
{

	protected WebsiteArticle Article;

	protected void Page_Load(object sender, EventArgs e)
	{

		var name = Request["name"];

		//WebsiteArticle.GetById


	}
}