using AdAndLifeWebsite.Models.Tickets;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
		protected SellingTransaction Trans;
		protected string Base64barcode;
		protected bool IsEmailSent = false;

		protected string Seats
		{
			get
			{
				var s = "";
				foreach (var t in Tickets) {
					s += t.Seat + ", ";
				}
				return s.Trim(',', ' ');
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{

			//EMailSender.SendTicketToUser()
			

			try
			{
				var transId = (int)Session["transactionId"];
				Trans = SellingTransaction.GetById(transId);
				if (Trans == null) throw new Exception("can't find transaction id=" + transId.ToString());

				Sale = SaleEvent.GetById(Trans.EventId);
				if (Sale == null) throw new Exception("can't find sale");

				Tickets = Ticket.GetTicketsForTransaction(Trans);

			}
			catch 
			{
				Response.Redirect("/tickets.aspx");
			}

			QRCodeGenerator qrGenerator = new QRCodeGenerator();
			QRCodeData qrCodeData = qrGenerator.CreateQrCode("http://adandlife.com/checkTicket.aspx?c=" + Trans.RedeemCode, QRCodeGenerator.ECCLevel.Q);
			QRCode qrCode = new QRCode(qrCodeData);
			Bitmap qrCodeImage = qrCode.GetGraphic(20);

			System.IO.MemoryStream stream = new System.IO.MemoryStream();
			qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
			byte[] imageBytes = stream.ToArray();

			Base64barcode = Convert.ToBase64String(imageBytes);


		}


		protected override void Render(HtmlTextWriter writer)
		{
			StringBuilder sbOut = new StringBuilder();
			StringWriter swOut = new StringWriter(sbOut);
			HtmlTextWriter htwOut = new HtmlTextWriter(swOut);
			base.Render(htwOut);
			string sOut = sbOut.ToString();

			if (Session["ticketSentToEmail"] == null)
			{
				IsEmailSent = EMailSender.SendTicketToUser(Trans.Email, Trans.Name, "Ваш электронный билет - " + Sale.EventName, sOut);
				Session.Add("ticketSentToEmail", "1");
			}

			writer.Write(sOut);
		}

	}
}