using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{
	public partial class CheckTicketLogin : System.Web.UI.Page
	{



		protected void Page_Load(object sender, EventArgs e)
		{

			if (Request["pass"] == "aal")
			{
				Response.Cookies.Add(new HttpCookie("passCheckOk", "1") { HttpOnly = true, Expires = DateTime.Now.AddYears(1) });
				Response.Write("<h1>Now you are logged in. Please scan a ticket to get started.</h1>");
				Response.End();
			}

		}
	}
}