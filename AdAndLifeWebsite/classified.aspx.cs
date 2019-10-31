using AdAndLifeWebsite.Classes;
using AdAndLifeWebsite.Models.Classified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{
    public partial class ClassifiedPage : System.Web.UI.Page
    {

        protected string CanonicalUrl = "http://adandlife.com/classified.aspx";
        protected string OgTitle = "Classified";
		protected string RubricMenuTitle;
		protected ClassifiedRubric Rubric;
		protected IEnumerable<ClassifiedRubric> Rubrics;
		protected IEnumerable<ClassifiedAd> Ads;

		protected void Page_Init(object sender, EventArgs e)
		{
			(Master as MainMaster).PageTitle = Utility.IsBaltimore ? "Объявления в Балтиморе (Baltimore)" : "Объявления в Филадельфии";
			(Master as MainMaster).MetaDescription = "Спрос и предложения труда, рент квартир и комнат, занятия, продам/куплю, услуги, business opportunities в " + (Utility.IsBaltimore ? "Балтиморе" : "Филадельфии");
		}

		protected void Page_Load(object sender, EventArgs e)
        {

            //ClassifiedAd.ReloadAllFromDb();

            int adId;
			int.TryParse(Request["ad"], out adId);

			int rubricId;
			int.TryParse(Request["rubric"], out rubricId);

			RubricMenuTitle = "Все рубрики";


			int state = Utility.IsBaltimore ? ClassifiedAd.BALTIMORE : ClassifiedAd.PA;
            Ads = ClassifiedAd.All[state];
			Rubrics = ClassifiedRubric.All[state].Where((x) => x.Ads.Count > 0);

			if (adId > 0)
            {
                Ads = Ads.Where((x) => x.Id == adId);
				var ad = Ads.FirstOrDefault();
                if (ad != null)
                {
                    CanonicalUrl += "?ad=" + adId.ToString();
                    OgTitle = ad.Text;
                }
            } else if (!string.IsNullOrEmpty(SearchBar.Value))
			{
				Ads = Ads.Where((c) => c.Text.ToLower().Contains(SearchBar.Value.ToLower()));
			}
			else if (rubricId != 0)
			{
				Rubric = Rubrics.FirstOrDefault((x) => x.Id == rubricId);
				if (Rubric != null)
				{
					Ads = Ads.Where((c) => c.Rubric.Id == rubricId);
					RubricMenuTitle = Rubric.Name;
				}
			}

			ClassifiedRepeater.DataSource = Ads.OrderBy((x) => x.IsPromoting ? 0 : 1);
			ClassifiedRepeater.DataBind();

        }
    }
}