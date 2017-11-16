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

        protected int CurrentRubricId = 0;
        protected string CanonicalUrl = "http://adandlife.com/classified.aspx";
        protected string OgTitle = "Classified";

		protected void Page_Init(object sender, EventArgs e)
		{
			(Master as MainMaster).PageTitle = Utility.IsBaltimore ? "Объявления в Балтиморе (Baltimore)" : "Объявления в Филадельфии";
			(Master as MainMaster).MetaDescription = "Спрос и предложения труда, рент квартир и комнат, занятия, продам/куплю, услуги, business opportunities в " + (Utility.IsBaltimore ? "Балтиморе" : "Филадельфии");
		}

		protected void Page_Load(object sender, EventArgs e)
        {

            //ClassifiedAd.ReloadAllFromDb();

            int adId = 0;

            try
            {
                CurrentRubricId = int.Parse(Request["rubric"]);
            }
            catch { }

            try
            {
                if (Request["ad"] != null) adId = int.Parse(Request["ad"]);
            }
            catch { }

            int state = Utility.IsBaltimore ? ClassifiedAd.BALTIMORE : ClassifiedAd.PA;

            IEnumerable<ClassifiedAd> ads = ClassifiedAd.All[state];

            if (adId > 0)
            {
                ClassifiedRepeater.DataSource = ads.Where((x) => x.Id == adId);

                var ad = ads.FirstOrDefault((x) => x.Id == adId);
                if (ad != null)
                {
                    CanonicalUrl += "?ad=" + adId.ToString();
                    OgTitle = ad.Text;
                }

            } else
            {
                if (CurrentRubricId != 0)
                {
                    ads = ads.Where((c) => c.Rubric.Id == CurrentRubricId);
                }

                if (!string.IsNullOrEmpty(SearchBar.Value))
                {
                    ads = ads.Where((c) => c.Text.ToLower().Contains(SearchBar.Value.ToLower()));
                }

                ClassifiedRepeater.DataSource = ads.OrderBy((x) => x.IsPromoting ? 0 : 1);
            }

            ClassifiedRepeater.DataBind();



            RubricRepeater.DataSource = ClassifiedRubric.All[state].Where((x) => x.Ads.Count > 0);
            RubricRepeater.DataBind();

        }
    }
}