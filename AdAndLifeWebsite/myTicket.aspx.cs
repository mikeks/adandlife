using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite
{
	public partial class MyTicket : System.Web.UI.Page
	{

		protected string GetRequestData()
		{


			using (var reader = new StreamReader(Request.InputStream))
			{
				return reader.ReadToEnd();
			}
		}


		protected SaleEvent Sale;
		protected IEnumerable<Ticket> Tickets;



		protected void Page_Load(object sender, EventArgs e)
		{

			//EMailSender.SendTicketToUser()


			try
			{
				var transId = (int)Session["transactionId"];
				var tr = SellingTransaction.GetById(transId);
				if (tr == null) throw new Exception("can't find transaction id=" + transId.ToString());

				Sale = SaleEvent.GetById(tr.EventId);
				if (Sale == null) throw new Exception("can't find sale");

				Tickets = Ticket.GetTicketsForTransaction(tr);

			}
			catch 
			{
				Response.Redirect("/tickets.aspx");
			}



		}
	}
}