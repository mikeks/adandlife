using AdAndLifeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        public string ErrorMsg = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["login"] != null && Request["password"] != null)
            {
                var lp = ConfigurationManager.AppSettings["adminAccess"].Split('|');
                if (Request["login"] == lp[0] && Request["password"] == lp[1])
                {
                    SiteUser.SetAdmin();
                    Response.Redirect("/Admin/Default.aspx");
                } else
                {
                    ErrorMsg = "Неверный логин или пароль";
                }
            }

        }
    }
}