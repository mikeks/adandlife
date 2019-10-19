using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{
    public partial class ArticlesPage : System.Web.UI.Page
    {
		protected ArticleRubric Rubric;
		protected void Page_Init(object sender, EventArgs e)
		{
			(Master as MainMaster).PageTitle = "Статьи";
			(Master as MainMaster).MetaDescription = "Статьи из газеты \"Реклама и Жизнь\"";
		}


		protected void Page_Load(object sender, EventArgs e)
        {

			int rubricId = 0;
			int.TryParse(Request["rubricId"], out rubricId);

			var allArticles = WebsiteArticle.All;

			IEnumerable<WebsiteArticle> articles = allArticles.OrderByDescending((x) => x.Created).ToList();

			if (rubricId > 0)
			{
				Rubric = ArticleRubric.GetById(rubricId);
				articles = articles.Where((x) => x.Rubric != null && x.Rubric.Id == rubricId);
			}

			ARep.DataSource = articles;
			ARep.DataBind();

			RepRubric.DataSource = ArticleRubric.All.OrderByDescending((r) => allArticles.Count((a) => a.Rubric.Id == r.Id)).Take(8);
			RepRubric.DataBind();
		}
	}
}