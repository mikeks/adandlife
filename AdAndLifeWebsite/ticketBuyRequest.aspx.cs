using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{
	public partial class TicketBuyRequest : System.Web.UI.Page
	{
		protected SaleEvent Sale;
		protected List<Ticket> Tickets;
		protected int TransactionId;
		//protected decimal FeePerTicket;

		protected void Page_Load(object sender, EventArgs e)
		{
			
			try
			{
				var id = int.Parse(Request.Form["eventId"]);
				Sale = SaleEvent.GetById(id);
				if (Sale == null || !Sale.IsAvaliable) throw new Exception();

				var name = Request["buyerName"];
				var email = Request["buyerEmail"];
				var userRefferer = Request["userRefferer"];
				bool subscribe = Request["subscribe"] != null;

				if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email)) throw new Exception();

				if (string.IsNullOrWhiteSpace(Request.Form["seats"])) throw new Exception();
				var seats = Request.Form["seats"].Trim(',').Split(',');

				Tickets = new List<Ticket>();
				foreach (var seat in seats)
				{
					var t = Sale.AvaliableTickets.First((x) => x.Seat == seat);
					Tickets.Add(t);
				}

				//var totalFee = 0.3M + 0.029M * (Tickets.Sum((x) => x.Price));
				//FeePerTicket = totalFee / Tickets.Count;

				var b = new SellingTransaction(name, email, userRefferer, subscribe);
				b.BeginSellingTransaction(Sale, Tickets);
				TransactionId = b.Id;

			}
			catch (Exception er)
			{
				DbObject.ExecStoredProc("ticket.LogTransaction", (cmd) => cmd.Parameters.AddWithValue("@data", "ERR REQ: " + er.Message));
				Response.Redirect("/tickets.aspx", true);
			}



		}
	}
}