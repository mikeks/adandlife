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


    public partial class TicketPage : System.Web.UI.Page
    {

        protected SaleEvent Sale;
		protected bool StartStep1 = false;

        protected void Page_Load(object sender, EventArgs e)
        {
			(Master as MainMaster).HideBanners = true;

			StartStep1 = Request.RawUrl.Contains("?buy");

            try
            {
                //var aId = int.Parse(Request["id"]);
                var url = Request["url"];
                if (url == null) throw new Exception();
                Sale = SaleEvent.GetByUrl(url);

				if (Sale == null) throw new Exception();

				var cont = Page.Master.FindControl("ContentAreaNoForm");
				cont.FindControl("hmKleinLife").Visible = Sale.Location.Code == "KleinLife";
				cont.FindControl("hmArchWood").Visible = Sale.Location.Code == "ArchWood";

            }
            catch (Exception)
            {
                Response.Redirect("/tickets.aspx", true);
            }



        }
    }
}