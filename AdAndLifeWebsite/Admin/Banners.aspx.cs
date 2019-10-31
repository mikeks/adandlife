using AdAndLifeWebsite.Models;
using System;

namespace AdAndLifeWebsite.Admin
{
	public partial class Banners : System.Web.UI.Page
	{

		protected string PosToStr(Object pos)
		{
			var p = (int)pos;
			if (p == 0) return "скрыто";
			return p.ToString();
		}

		protected bool IsBannerActive(Object bnr)
		{
			var b = (SiteBanner)bnr;
			if (b.PositionHomepage == 0 && b.PositionRight == 0) return false;
			return b.EndDate > DateTime.Now;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			SiteUser.CheckPageAccess("banners");

			if (Request["del"] != null)
			{
				int delId = int.Parse(Request["del"]);
				SiteBanner.GetById(delId).Delete();
				Response.Redirect("Banners.aspx");
			}

			RepeaterBanners.DataSource = SiteBanner.All;
			RepeaterBanners.DataBind();

			

		}
    }
}