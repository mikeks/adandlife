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

					var trans = SellingTransaction.GetById(transId);
					if (trans == null) throw new Exception("can't find transaction id=" + transId.ToString());
					trans.CompleteTransaction(transactionCode);

					trans = SellingTransaction.GetById(transId); // read again to pick up redeem code

					var sale = SaleEvent.GetById(trans.EventId);
					if (sale == null) throw new Exception("can't find sale");

					var lnk = "http://www.adandlife.com/myTicket.aspx?r=" + trans.RedeemCode + trans.Id;

					var emailText = "Уважаемый " + trans.Name + ". Ваш электронный билет на \"" + sale.EventName + "\" Вы можете распечатать, пройдя по ссылке: "
						+ "<a href=\"" + lnk + "\">" + lnk + "</a>.<br><br>Спасибо за то, что воспользовались сервисом продажи билетов.<br>Реклама и Жизнь, Филадельфия.";

					EMailSender.SendTicketToUser(trans.Email, trans.Name, "Билет: " + sale.EventName, emailText);

					var adminEmailText = $"Куплен билет на {sale.EventName} ({sale.EventDate}).";
					EMailSender.SendEmail("admin@adandlife.com", "Ad & Life website", "Куплен билет", "", adminEmailText);

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