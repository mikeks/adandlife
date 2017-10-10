using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite
{
	public partial class TicketReturn : System.Web.UI.Page
	{

		protected string GetRequestData()
		{


			using (var reader = new StreamReader(Request.InputStream))
			{
				return reader.ReadToEnd();
			}
		}


		protected void Page_Load(object sender, EventArgs e)
		{

			DbObject.ExecStoredProc("ticket.LogTransaction", (cmd) => cmd.Parameters.AddWithValue("@data", Request.RawUrl));

			bool isSuccess = Request["st"] == "Completed";

			if (isSuccess)
			{

				try
				{
					var transId = int.Parse(Request["cm"]);
					var transactionCode = Request["tx"];

					var b = SellingTransaction.GetById(transId);
					if (b == null) throw new Exception("can't find transaction id=" + transId.ToString());
					b.CompleteTransaction(transactionCode);

					Session.Add("transactionId", transId);
				}
				catch (Exception er)
				{
					DbObject.ExecStoredProc("ticket.LogTransaction", (cmd) => cmd.Parameters.AddWithValue("@data", "PROC ERR: " + er.Message + " (" + Request.RawUrl + ")"));
				}

				Response.Redirect("/myTicket.aspx", true);
			}


		}
	}
}