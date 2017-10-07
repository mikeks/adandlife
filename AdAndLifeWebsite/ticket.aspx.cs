using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{


    public partial class Ticket : System.Web.UI.Page
    {

        protected TicketsSale Sale;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //var aId = int.Parse(Request["id"]);
                var url = Request["url"];
                if (url == null) throw new Exception();
                Sale = TicketsSale.GetByUrl(url);
                if (Sale == null) throw new Exception();
            }
            catch (Exception)
            {
                Response.Redirect("/tickets.aspx", true);
            }



        }
    }
}