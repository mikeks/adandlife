using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Articles.Entities;
using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite
{
    public partial class TicketsPage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            EventsRepeater.DataSource = SaleEvent.AllForSale;
            EventsRepeater.DataBind();
        }
    }
}