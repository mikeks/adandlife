using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Articles.Entities;
using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite.Admin
{
	public partial class EditTickets : System.Web.UI.Page
	{

        public SaleEvent Sale;
        public string ErrorMessage = "";
		public bool IsSaved = false;
		//protected string ExistingTickets = "";

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


			RepeaterExistingTickets.DataSource = Sale.AllTickets;
			RepeaterExistingTickets.DataBind();


			//foreach (var t in Sale.AllTickets)
			//{
			//	ExistingTickets += $"{t.Seat} (${t.Price:0}), ";
			//	t.Price
			//}
			//ExistingTickets = ExistingTickets.Trim(',', ' ');

			bool isChanged = false;

			if (IsPostBack)
			{


				if (!string.IsNullOrWhiteSpace(TicketsToAdd.Text))
				{
					decimal price;
					try
					{
						price = decimal.Parse(TicketPrice.Text);
					}
					catch
					{
						ErrorMessage = "Цена указана неверно";
						return;

					}
					foreach (var seat in TicketsToAdd.Text.Split(','))
					{
						try
						{
							Ticket.CreateNew(Sale.Id, price, seat);
							isChanged = true;
						}
						catch
						{
							ErrorMessage += $"Не удалось добавить билет {seat} ({price:0})<br>";
						}
					}
				}

				if (!string.IsNullOrWhiteSpace(TicketsToDelete.Text))
				{
					foreach (var seat in TicketsToDelete.Text.Split(','))
					{
						try
						{
							Ticket.DeleteTicket(Sale.Id, seat);
							isChanged = true;
						}
						catch
						{
							ErrorMessage += $"Не удалось удалить билет {seat}<br>";
						}
					}
				}

				if (isChanged)
				{
					Response.Redirect(Request.RawUrl);
				}

			}

		}
	}
}