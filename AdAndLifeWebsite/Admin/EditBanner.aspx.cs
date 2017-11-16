using AdAndLifeWebsite.Models;
using AdAndLifeWebsite.Models.Admin;
using AdAndLifeWebsite.Models.Articles.Entities;
using AdAndLifeWebsite.Models.Tickets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite.Admin
{
	public partial class EditBanner : System.Web.UI.Page
	{

		protected SiteBanner Banner;
        protected string ErrorMessage = "";
		protected bool IsSaved = false;

		private void FillPostionDD(DropDownList list)
		{
			list.Items.Clear();
			list.Items.Add(new ListItem("Скрыть", "0"));
			list.Items.Add(new ListItem("В позиции 1 (сверху)", "1"));
			for (int i = 2; i < 100; i++)
			{
				list.Items.Add(new ListItem($"В позиции {i}", i.ToString()));
			}

		}

		protected void Page_Load(object sender, EventArgs e)
		{
			SiteUser.CheckPageAccess("banners");

			if (!IsPostBack)
			{
				FillPostionDD(ddPositionHomepage);
				FillPostionDD(ddPositionRight);
			}

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
                Banner = SiteBanner.GetById(id);
			} else
			{
				Banner = new SiteBanner();
			}


			if (IsPostBack)
			{

                if (string.IsNullOrWhiteSpace(BannerName.Text))
                {
                    ErrorMessage = "Укажите название";
                    return;
                }
				Banner.Name = BannerName.Text;

				if (!FileUpload1.HasFiles && Banner.ImageFilename == null)
				{
					ErrorMessage = "Пожалуйста, загрузите изображение баннера.";
					return;
				}

				try
				{
					Banner.Price = decimal.Parse(BannerPrice.Text);
				}
				catch
				{
					ErrorMessage = "Пожалуйста, верно укажите цену баннера.";
					return;
				}

				try
				{
					Banner.EndDate = DateTime.Parse(BannerEndDate.Text);
				}
				catch
				{
					ErrorMessage = "Пожалуйста, верно укажите дату снятия баннера.";
					return;
				}

				Banner.PositionHomepage = int.Parse(ddPositionHomepage.SelectedValue);
				Banner.PositionRight = int.Parse(ddPositionRight.SelectedValue);

				if (FileUpload1.HasFiles)
				{
					var fn = FileUpload1.FileName;
					var ext = Path.GetExtension(fn).ToLowerInvariant();
					if (ext != ".png" && ext != ".jpg")
					{
						ErrorMessage = "Баннер не загружен. Требуется формат PNG или JPG.";
						return;
					}
					try
					{
						Banner.SaveImage(FileUpload1.FileBytes, Path.GetFileNameWithoutExtension(fn));
					}
					catch (Exception ee)
					{
						ErrorMessage = "Баннер не загружен. " + ee.Message;
						return;
					}
				}

				Banner.Save();

				IsSaved = true;
			}

			BannerName.Text = Banner.Name;

			ddPositionRight.SelectedIndex = Banner.PositionRight;
			ddPositionHomepage.SelectedIndex = Banner.PositionHomepage;

			if (Banner.EndDate != DateTime.MinValue) BannerEndDate.Text = Banner.EndDate.ToString("yyyy-MM-dd");
			BannerPrice.Text = Banner.Price.ToString("0.##");

		}
    }
}