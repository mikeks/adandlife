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

        public bool IsAdmin => Models.SiteUser.IsAdmin;

        public string DomainPA => Utility.DomainPA;
        public string DomainBaltimore => Utility.DomainBaltimore;

        protected bool IsBaltimore => Utility.IsBaltimore;

        protected string CurrentUrlInBaltimore => Request.Url.ToString().Replace("adandlife", "baltimore.adandlife");
        protected string CurrentUrlInPA => Request.Url.ToString().Replace("baltimore.", "");

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