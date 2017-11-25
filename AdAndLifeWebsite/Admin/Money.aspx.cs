using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Admin;
using AdAndLifeWebsite.Models.Articles.Entities;
using AdAndLifeWebsite.Models.Classified;
using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite.Admin
{
	public partial class MoneyPage : System.Web.UI.Page
	{

		protected decimal classifiedTotalPrice;
		protected decimal classifiedMike;
		protected decimal ticketsTotalPrice;
		protected decimal ticketsOurShare;
		protected decimal ticketsMike;
		protected decimal bannersTotalPrice;
		protected decimal bannersMike;
		protected decimal totalChecks;
		protected decimal totalMike;
		protected decimal balanceMike;


		protected void Page_Load(object sender, EventArgs e)
		{
			SiteUser.CheckPageAccess("money");

			// classified
			var allClassified = ClassifiedMoney.All;
			RepeaterClassifedMoney.DataSource = allClassified;
			RepeaterClassifedMoney.DataBind();

			classifiedTotalPrice = 0;
			foreach (var ad in allClassified)
			{
				classifiedTotalPrice += ad.Price;
			}
			classifiedMike = classifiedTotalPrice * 0.45m;

			// tickets
			RepeaterTickets.DataSource = SaleEvent.All;
			RepeaterTickets.DataBind();

			ticketsTotalPrice = 0;
			ticketsOurShare = 0;
			foreach (var ev in SaleEvent.All)
			{
				ticketsTotalPrice += ev.TotalSoldAmount;
				ticketsOurShare += ev.OurShareUSD;
			}
			ticketsMike = ticketsOurShare * 0.45m;

			// banners
			RepeaterBanners.DataSource = SiteBanner.All;
			RepeaterBanners.DataBind();

			bannersTotalPrice = 0;
			foreach (var bn in SiteBanner.All)
			{
				bannersTotalPrice += bn.Price;
			}
			bannersMike = bannersTotalPrice * 0.45m;


			// received checks
			RepeaterMikeMoney.DataSource = MikeMoney.All;
			RepeaterMikeMoney.DataBind();

			if (Request["delPayment"] != null)
			{
				int id = int.Parse(Request["delPayment"]);
				MikeMoney.All.First((x) => x.Id == id).Delete();
				Response.Redirect("Money.aspx", true);
			}

			if (!IsPostBack)
			{
				txDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			}

			totalChecks = MikeMoney.All.Sum((x) => x.Amount);

			totalMike = bannersMike + ticketsMike + classifiedMike;
			balanceMike = totalMike - totalChecks;

			AddPayment.Click += AddPayment_Click;

		}

		private void AddPayment_Click(object sender, EventArgs e)
		{
			var mn = new MikeMoney()
			{
				Created = DateTime.Parse(txDate.Text),
				Amount = decimal.Parse(txMoney.Text)
			};
			mn.Save();
			Response.Redirect("Money.aspx");
		}
	}
}