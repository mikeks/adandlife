using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{
	public partial class checkTicket : System.Web.UI.Page
	{

		private SellingTransaction Trans = null;

		protected string Conclusion;
		protected string Color;
		protected string ErrorMessage = "";
		protected string Descr = "";


		protected void Page_Load(object sender, EventArgs e)
		{

			if (Request.Cookies["passCheckOk"] == null)
			{
				Response.Redirect("/checkTicketLogin.aspx", true);
			}

			try
			{
				var code = Request["c"];
				if (string.IsNullOrWhiteSpace(code)) throw new Exception("Code not provided");
				Trans = SellingTransaction.GetByRedeemCode(code);
				if (Trans == null) throw new Exception("Transaction not found");

				var ev = SaleEvent.GetById(Trans.EventId);

				var tickets = Ticket.GetTicketsForTransaction(Trans);



				Descr = "Event: " + ev.EventName + " (" + ev.EventDate + ")<br>"
					+ "Seats (" + tickets.Count() + "): " + tickets.Select((x) => x.Seat).Aggregate((a, b) => a + ", " + b) 
					+ "<br>Code: " + Trans.RedeemCode;

				Trans.TicketRedeemed();
				
			}
			catch  (Exception ee)
			{
				ErrorMessage = ee.Message;
			}

			if (Trans == null)
			{
				Conclusion = "Invalid ticket";
				Color = "red";
				return;
			}

			if (Trans.RedeemDateTime == null)
			{
				Conclusion = "Valid ticket";
				Color = "green";
				return;
			}

			Conclusion = "Ticket already scanned";
			Color = "#808064";
			ErrorMessage = "Last scanned: " + Trans.RedeemDateTime.ToString();

		}
	}
}