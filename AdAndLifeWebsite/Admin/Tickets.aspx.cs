using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite.Admin
{
	public partial class Tickets : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            SalesRepeater.DataSource = TicketsSale.All;
            SalesRepeater.DataBind();

            if (Request["del"] != null)
            {
                int delId = int.Parse(Request["del"]);
                TicketsSale.Delete(delId);
                Response.Redirect("Tickets.aspx");
            }

		}
	}
}