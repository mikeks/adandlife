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
	public partial class EditEvent : System.Web.UI.Page
	{

        public SaleEvent Sale;
        public string ErrorMessage = "";
		public bool IsSaved = false;

		protected void Page_Load(object sender, EventArgs e)
		{

			int id = 0;
			try
			{
				id = int.Parse(Request["id"]);
			}
			catch 
			{
			}
		

			if (id > 0)
			{
                Sale = SaleEvent.GetById(id);
			} else
			{
                Sale = new SaleEvent();
			}


			if (IsPostBack)
			{

                if (string.IsNullOrWhiteSpace(EventName.Text))
                {
                    ErrorMessage = "Укажите название";
                    return;
                }


                Sale.EventName = EventName.Text;
                Sale.EventDescription = EventDescription.InnerText;
                //Sale.TotalTicketCount = int.Parse(TicketsCount.Text);
                Sale.IsAvaliable = IsAvaliable.Checked;
                //Sale.PaypalButtonCode = PayPalCodeButton.InnerText;
                Sale.UrlName = UrlName.Text;

                Sale.Save();

                IsSaved = true;
			}


            EventName.Text = Sale.EventName;
            EventDescription.InnerText = Sale.EventDescription;
            //TicketsCount.Text = Sale.TotalTicketCount.ToString();
            IsAvaliable.Checked = Sale.IsAvaliable;
            //PayPalCodeButton.InnerText = Sale.PaypalButtonCode;
            UrlName.Text = Sale.UrlName;

        }
    }
}