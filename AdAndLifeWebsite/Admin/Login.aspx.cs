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
			if (Request["mode"] == "exit")
			{
				SiteUser.Logout();
				Response.Redirect("/", true);
			}

			var login = Request["login"];
			var password = Request["password"];

			if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
            {
				var user = SiteUser.Login(login, password);
				if (user != null)
				{
                    Response.Redirect("/Admin/Default.aspx");
                } else
                {
                    ErrorMsg = "Неверный логин или пароль";
                }
            }

        }
    }
}