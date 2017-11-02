using AdAndLifeWebsite.Classes;
using AdAndLifeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {

		public bool HideBanners { get; set; } = false;
		public bool NoWidthLimit { get; set; } = false;

		public string MetaDescription { get; set; } = "Реклама и Жизнь, Еврейская Жизнь - популярные бесплатные газеты объявление в Филадельфии, New Jersey, Baltimore. Classified, объявления, реклама, статьи, билеты.";

		public string PageTitle { get; set; }

		public bool IsAdmin => Models.SiteUser.IsAdmin;

        public string DomainPA => Utility.DomainPA;
        public string DomainBaltimore => Utility.DomainBaltimore;

        protected bool IsBaltimore => Utility.IsBaltimore;

        protected string CurrentUrlInBaltimore => Request.Url.ToString().Replace("adandlife", "baltimore.adandlife");
        protected string CurrentUrlInPA => Request.Url.ToString().Replace("baltimore.", "");

		protected void Page_Init(object sender, EventArgs e)
		{
			PageTitle = "Реклама и Жизнь — бесплатная газета объявлений. " + (IsBaltimore ? "Baltimore (Балтимор), Washington, DC" : "Philadelphia (Филадельфия), New Jersey") + ", США";
		}

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        bool _isAnySel = false;

        protected string _isSel(string url)
        {
            if (Request.Url.LocalPath.ToLowerInvariant().Contains(url.ToLowerInvariant()))
            {
                _isAnySel = true;
                return "-sel";
            }
            return "";
        }

    }
}