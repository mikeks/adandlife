using AdAndLifeWebsite.Classes;
using AdAndLifeWebsite.Models.Articles.Entities;
using AdAndLifeWebsite.Models.Classified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{
    public partial class DefaultPage : System.Web.UI.Page
    {
		protected ArticleRubric Rubric;
		protected IEnumerable<ArticleRubric> Rubrics;
		protected string HeaderTitle;
		protected string RubricMenuTitle;
		protected IEnumerable<WebsiteArticle> Articles;
		protected List<ClassifiedAd> Ads;
		protected int PageNumber;
		protected int TotalPages;
		private int RubricId;
		protected bool IsMainPage = true;

		protected void Page_Init(object sender, EventArgs e)
		{
			(Master as MainMaster).PageTitle = "Статьи";
			(Master as MainMaster).MetaDescription = "Статьи из газеты \"Реклама и Жизнь\"";
		}

		protected string GetPageLink(int page)
		{
			if (RubricId == 0) return $"/?page={page}";
			return $"/rubric={RubricId}&page={page}";
		}

		protected void Page_Load(object sender, EventArgs e)
        {


			RubricId = 0;
			int.TryParse(Request["rubric"], out RubricId);

			HeaderTitle = "Реклама и Жизнь - " + (Utility.IsBaltimore ? "Балтимор" : "Филадельфия");
			RubricMenuTitle = "Все рубрики";

			var allArticles = WebsiteArticle.All;

			if (RubricId > 0)
			{
				Rubric = ArticleRubric.GetById(RubricId);
				if (Rubric != null)
				{
					Articles = allArticles.Where((x) => x.Rubric != null && x.Rubric.Id == RubricId);
					HeaderTitle = Rubric.Name;
					RubricMenuTitle = Rubric.Name;
					IsMainPage = false;
				}
			} else
			{
				Articles = allArticles;
			}

			const int ARTICLES_PER_PAGE = 20;

			TotalPages = (int)Math.Ceiling(Articles.Count() * 1.0 / ARTICLES_PER_PAGE);
			int.TryParse(Request["page"], out PageNumber);
			if (PageNumber <= 0 || PageNumber > TotalPages) PageNumber = 1;

			Articles = Articles.OrderByDescending((x) => x.Created).Skip(ARTICLES_PER_PAGE * (PageNumber - 1)).Take(ARTICLES_PER_PAGE).ToList();


			//ARep.DataSource = articles;
			//ARep.DataBind();

			Rubrics = ArticleRubric.All.Where((r) => allArticles.Any((a) => a.Rubric.Id == r.Id)).OrderBy((r) => r.Name);


			int state = Utility.IsBaltimore ? ClassifiedAd.BALTIMORE : ClassifiedAd.PA;

			Ads = ClassifiedAd.All[state].Where((x) => x.IsPromoting).ToList();


			//RepRubric.DataSource = ArticleRubric.All.OrderByDescending((r) => allArticles.Count((a) => a.Rubric.Id == r.Id)).Take(8);
			//RepRubric.DataBind();
		}
	}
}