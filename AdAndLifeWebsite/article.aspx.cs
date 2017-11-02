using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{


    public partial class ArticlePage : System.Web.UI.Page
    {

        protected string CanonicalUrl;

        protected WebsiteArticle Article;


		protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                var aId = int.Parse(Request["id"]);
                Article = WebsiteArticle.GetById(aId);
                CanonicalUrl = "http://adandlife.com/article.aspx?id=" + aId.ToString();

				(Master as MainMaster).PageTitle = Article.Name;
				(Master as MainMaster).MetaDescription = "Статья из газеты: " + Article.Name;

			}
			catch (Exception)
            {
                Response.Redirect("/articles.aspx", true);
            }



        }
    }
}