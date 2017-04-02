using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite
{
    public partial class classified : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ClassifiedAd.ReloadAllFromDb();

            int rubricId = 0;
            try
            {
                rubricId = int.Parse(Request["rubric"]);
            }
            catch {}

            IEnumerable<ClassifiedAd> ads = ClassifiedAd.All; ;

            if (rubricId != 0)
            {
                ads = ads.Where((c) => c.Rubric.Id == rubricId);
            }

            if (!string.IsNullOrEmpty(SearchBar.Text))
            {
                ads = ads.Where((c) => c.Text.ToLower().Contains(SearchBar.Text.ToLower()));
            }


            ClassifiedRepeater.DataSource = ads;
            ClassifiedRepeater.DataBind();



            RubricRepeater.DataSource = ClassifiedRubric.All;
            RubricRepeater.DataBind();

        }
    }
}