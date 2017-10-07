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