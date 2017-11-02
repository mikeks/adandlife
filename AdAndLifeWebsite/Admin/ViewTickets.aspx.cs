using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Articles.Entities;
using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite.Admin
{
	public partial class ViewTickets : System.Web.UI.Page
	{

        public SaleEvent Sale;
		protected IEnumerable<SellingTransaction> Transactions;
        //public string ErrorMessage = "";

		protected void Page_Load(object sender, EventArgs e)
		{

			int id = 0;
			try
			{
				id = int.Parse(Request["id"]);
				Sale = SaleEvent.GetById(id);
			}
			catch 
			{
				Response.Redirect("Tickets.aspx", true);
			}

			Transactions = Sale.GetTransactions();

		}
    }
}