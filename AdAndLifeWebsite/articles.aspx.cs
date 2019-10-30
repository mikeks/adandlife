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
		protected IEnumerable<ArticleRubric> Rubrics;
		protected string HeaderTitle;
		protected string RubricMenuTitle;

		protected void Page_Init(object sender, EventArgs e)
		{
			(Master as MainMaster).PageTitle = "Статьи";
			(Master as MainMaster).MetaDescription = "Статьи из газеты \"Реклама и Жизнь\"";
		}


		protected void Page_Load(object sender, EventArgs e)
        {

			int rubricId = 0;
			int.TryParse(Request["rubricId"], out rubricId);

			HeaderTitle = "Статьи";
			RubricMenuTitle = "Все рубрики";

			var allArticles = WebsiteArticle.All;

			IEnumerable<WebsiteArticle> articles = allArticles.OrderByDescending((x) => x.Created).Take(50).ToList();

			if (rubricId > 0)
			{
				Rubric = ArticleRubric.GetById(rubricId);
				if (Rubric != null)
				{
					articles = articles.Where((x) => x.Rubric != null && x.Rubric.Id == rubricId);
					HeaderTitle = Rubric.Name;
					RubricMenuTitle = Rubric.Name;
				}
			}

			ARep.DataSource = articles;
			ARep.DataBind();

			Rubrics = ArticleRubric.All.Where((r) => allArticles.Any((a) => a.Rubric.Id == r.Id)).OrderBy((r) => r.Name);

			//RepRubric.DataSource = ArticleRubric.All.OrderByDescending((r) => allArticles.Count((a) => a.Rubric.Id == r.Id)).Take(8);
			//RepRubric.DataBind();
		}
	}
}