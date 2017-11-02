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
	public partial class ResendTicket : System.Web.UI.Page
	{

        protected SellingTransaction Trans;
		protected string Message;

		protected void Page_Load(object sender, EventArgs e)
		{

			int tid = 0;
			try
			{
				tid = int.Parse(Request["tid"]);
				Trans = SellingTransaction.GetById(tid);
			}
			catch 
			{
				Response.Redirect("Tickets.aspx", true);
			}

			if (IsPostBack)
			{
				if (!string.IsNullOrWhiteSpace(UserEmail.Text))
				{
					try
					{
						EMailSender.SendTicketToUser(Trans);
						Message = "Письмо отправлено успешно";
					}
					catch (Exception ee)
					{
						Message = "Не удалось отправить письмо. " + ee.Message;
					}
				}


			}

			UserEmail.Text = Trans.Email;


		}
    }
}