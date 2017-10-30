using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Articles.Entities;
using AdAndLifeWebsite.Models.Tickets;
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
            SalesRepeater.DataSource = SaleEvent.All;
            SalesRepeater.DataBind();

		}
	}
}