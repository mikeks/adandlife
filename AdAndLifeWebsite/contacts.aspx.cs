using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite
{
    public partial class ContactsPage : System.Web.UI.Page
    {

        protected string ErrorMsg = "";

        protected bool IsSent = false;
        protected string Name;
        protected string Email;
        protected string PhoneNumber;
        protected string Topic;
        protected string Msg;

		protected void Page_Init(object sender, EventArgs e)
		{
			(Master as MainMaster).PageTitle = "Связаться с редакцией газеты";
			(Master as MainMaster).MetaDescription = "Отправить заявку на объявление в газете, отзыв или предложение";
		}


		protected void Page_Load(object sender, EventArgs e)
        {

            Name = Request["msgName"];
            Email = Request["msgEmail"];
            PhoneNumber = Request["msgPhoneNumber"];
            Topic = Request["msgTopic"];
            Msg = Request["msgText"];


            if (Request["submitMessage"] != null)
            {
                if (string.IsNullOrWhiteSpace(Name))
                {
                    ErrorMsg = "Пожалуйста, укажите ваше имя.";
                }
                else
                if (string.IsNullOrWhiteSpace(Email) && string.IsNullOrWhiteSpace(PhoneNumber))
                {
                    ErrorMsg = "Пожалуйста, укажите ваш email или телефон, чтобы мы могли с вами связаться.";
                }
                else
                if (string.IsNullOrWhiteSpace(Topic))
                {
                    ErrorMsg = "Пожалуйста, укажите тему сообщения.";
                }
                else
                if (string.IsNullOrWhiteSpace(Msg))
                {
                    ErrorMsg = "Не заполнен текст сообщения.";
                }
                else if (!string.IsNullOrWhiteSpace(Email) && !EMailSender.IsValidEMail(Email))
                {
                    ErrorMsg = "Ошибка. Email указан не верно.";
                }
                else
                {
                    IsSent = EMailSender.SendEmail(Email, Name, Topic, PhoneNumber, Msg);
                    if (!IsSent)
                    {
                        ErrorMsg = "Произошла ошибка при отправки сообщения.";
                    }
                    else
                    {
                        Name = "";
                        Email = "";
                        Topic = "";
                        PhoneNumber = "";
                        Msg = "";
                    }
                }

            }

        }
    }
}