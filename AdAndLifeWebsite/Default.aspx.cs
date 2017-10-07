using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected WebsiteNewspaper lastPhila;
        protected WebsiteNewspaper lastBalt;
        protected WebsiteNewspaper lastJL;

        protected void Page_Load(object sender, EventArgs e)
        {
            var all = WebsiteNewspaper.All.OrderByDescending((x) => x.Year * 100 + x.Number);

            lastPhila = all.FirstOrDefault((x) => x.NewspaperType == NewspaperTypeEnum.AdAndLifePhila);
            lastBalt = all.FirstOrDefault((x) => x.NewspaperType == NewspaperTypeEnum.AdAndLifeBaltimore);
            lastJL = all.FirstOrDefault((x) => x.NewspaperType == NewspaperTypeEnum.JewishLife);


        }
    }
}