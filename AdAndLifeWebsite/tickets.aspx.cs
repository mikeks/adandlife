using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Articles.Entities;
using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{
    public partial class TicketsPage : System.Web.UI.Page
    {
		protected void Page_Init(object sender, EventArgs e)
		{
			(Master as MainMaster).HideBanners = true;
			(Master as MainMaster).NoWidthLimit = true;
			(Master as MainMaster).PageTitle = "Билеты на концерты";
			(Master as MainMaster).MetaDescription = "Купить билеты в Филадельфии, США (Philadelphia, USA)";
		}

		protected void Page_Load(object sender, EventArgs e)
        {
			EventsRepeater.DataSource = SaleEvent.AllForSale;
            EventsRepeater.DataBind();
        }
    }
}