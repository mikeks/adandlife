using AdAndLifeWebsite.Models;
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
	public partial class EditEvent : System.Web.UI.Page
	{

        public SaleEvent Sale;
        public string ErrorMessage = "";
		public bool IsSaved = false;

		protected void Page_Load(object sender, EventArgs e)
		{
			SiteUser.CheckPageAccess("tickets");

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


				if (string.IsNullOrWhiteSpace(EventDescription.InnerText))
				{
					ErrorMessage = "Укажите Анонс (описание)";
					return;
				}

				if (string.IsNullOrWhiteSpace(UrlName.Text))
				{
					ErrorMessage = "Укажите адрес URL";
					return;
				}

				if (Regex.IsMatch(UrlName.Text.Trim(), "[^a-z0-9]", RegexOptions.IgnoreCase))
				{
					ErrorMessage = "Адрес URL может содержать только латинские буквы и цифры.";
					return;
				}

				if (string.IsNullOrWhiteSpace(EventNameEng.Text))
				{
					ErrorMessage = "Укажите название по-английски";
					return;
				}

				if (Regex.IsMatch(EventNameEng.Text.Trim(), "[^a-z0-9 ]", RegexOptions.IgnoreCase))
				{
					ErrorMessage = "Название по-английски может содержать только латинские буквы, цифры или пробел.";
					return;
				}


				if (!FileUpload1.HasFiles && Sale.EventImage == null)
				{
					ErrorMessage = "Пожалуйста, загрузите рекламный плакат мероприятия (афишу).";
					return;
				}

				Sale.UrlName = UrlName.Text.Trim(); // should be before saving an image


				if (FileUpload1.HasFiles)
				{
					var fn = FileUpload1.FileName;
					var ext = Path.GetExtension(fn).ToLowerInvariant();
					if (ext != ".png" && ext != ".jpg")
					{
						ErrorMessage = "Афиша не загружена. Требуется формат PNG или JPG.";
						return;
					}
					try
					{
						Sale.SaveImage(FileUpload1.FileBytes);
					}
					catch (Exception ee)
					{
						ErrorMessage = "Афиша не загружена. " + ee.Message;
						return;
					}
				}



				Sale.EventName = EventName.Text.Trim();
                Sale.EventDescription = EventDescription.InnerText.Replace("\n", "<br>").Replace("\r", "");
                Sale.IsAvaliable = IsAvaliable.Checked;
				Sale.EventNameEng = EventNameEng.Text.Trim();
				try
				{
					Sale.EventDate = DateTime.Parse(EventDate.Text);
				}
				catch 
				{
					ErrorMessage = "Дата проведения мероприятия указана неверно.";
					return;
				}
				Sale.LocationId = int.Parse(EventLocationDropDown.SelectedValue);

				try
				{
					Sale.Save();
				}
				catch (Exception ee)
				{
					ErrorMessage = ee.Message.Contains("IX_SaleEvent_UrlName") ? "Этот адрес URL уже используется в другой активной продаже." : "Ошибка. " + ee.Message;
					return;
				}

				IsSaved = true;
			}

			 
            EventName.Text = Sale.EventName;
            EventDescription.InnerText = Sale.EventDescription.Replace("\r", "").Replace("\n", "").Replace("<br>", "\r\n");
			EventNameEng.Text = Sale.EventNameEng;
			IsAvaliable.Checked = Sale.IsAvaliable;
            UrlName.Text = Sale.UrlName;
			EventDate.Text = Sale.EventDate.ToString();

			EventLocation[] locs = EventLocation.All;
			EventLocationDropDown.DataSource = locs;

			int idx = Array.FindIndex(locs, (l) => l.Id == Sale.LocationId);
			if (idx >= 0) EventLocationDropDown.SelectedIndex = idx;
			EventLocationDropDown.DataBind();

		}
    }
}