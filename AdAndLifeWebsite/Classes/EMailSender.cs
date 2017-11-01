
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using AdAndLifeWebsite.Models.Tickets;

public class EMailSender
{


    public static bool SendEmail(string fromEmail, string fromName, string topic, string phoneNumber, string body)
    {
        try
        {
            //Dim smtp As New SmtpClient("smtp.gmail.com", 465)
            SmtpClient smtp = new SmtpClient("mail.chtogdekogda.org", 25);
            NetworkCredential cred = new NetworkCredential("admin@chtogdekogda.org", "ChtoGdeKogda2017");
            smtp.Credentials = cred;
            //smtp.EnableSsl = True
            smtp.Timeout = 10000;
            // 10 sec

            MailMessage Message = new MailMessage();
            //Message.From = New MailAddress(fromEmail, fromName)
            Message.From = new MailAddress("admin@adandlife.com");
            Message.To.Add("mkeskinov@gmail.com");
            Message.To.Add("vc.inc@aol.com");
            Message.Subject = topic;
            Message.Body = $"Сообщение с сайта adandlife.com. \n\n\r От: {fromName}\n\rEmail: {fromEmail}\n\rТел: {phoneNumber}\n\n\r{body}";
            Message.BodyEncoding = Encoding.UTF8;
            smtp.Send(Message);
            return true;
        }
        catch (Exception e)
        {
            dynamic m = e.Message;
        }
        return false;
    }

	public static bool SendTicketToUser(SellingTransaction trans)
	{
		var sale = trans.GetSale();
		var lnk = "http://www.adandlife.com/myTicket.aspx?r=" + trans.RedeemCode + trans.Id;

		var emailText = "Уважаемый " + trans.Name + ". Ваш электронный билет на \"" + sale.EventName + "\" Вы можете распечатать, пройдя по ссылке: "
			+ "<a href=\"" + lnk + "\">" + lnk + "</a>.<br><br>Спасибо за то, что воспользовались сервисом продажи билетов.<br>Реклама и Жизнь, Филадельфия.";

		return SendTicketToUser(trans.Email, trans.Name, "Билет: " + sale.EventName, emailText);
	}

	public static bool SendTicketToUser(string toEmail, string toName, string topic, string htmlBody)
	{
		try
		{
			//Dim smtp As New SmtpClient("smtp.gmail.com", 465)
			SmtpClient smtp = new SmtpClient("mail.chtogdekogda.org", 25);
			NetworkCredential cred = new NetworkCredential("admin@chtogdekogda.org", "ChtoGdeKogda2017");
			smtp.Credentials = cred;
			//smtp.EnableSsl = True
			smtp.Timeout = 10000;
			// 10 sec

			MailMessage Message = new MailMessage();
			//Message.From = New MailAddress(fromEmail, fromName)
			Message.From = new MailAddress("tickets@adandlife.com");
			Message.To.Add(new MailAddress(toEmail, toName));
			Message.Subject = topic;
			Message.IsBodyHtml = true;
			Message.Body = htmlBody;
			Message.BodyEncoding = Encoding.UTF8;
			smtp.Send(Message);
			return true;
		}
		catch (Exception e)
		{
			dynamic m = e.Message;
		}
		return false;
	}


	private static readonly Regex EMailValidationRegEx = new Regex("^(?!\\.)(\"([^\"\\r\\\\]|\\\\[\"\\r\\\\])*\"|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\\.)\\.)*)(?<!\\.)@[a-z0-9][\\w\\.-]*\\.[a-z][a-z\\.]*[a-z]$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public static bool IsValidEMail(string EMail)
    {
        if (EMail.EndsWith("."))
            return false;
        if (EMail.Contains(".."))
            return false;
        if (EMail.StartsWith("@"))
            return false;
        if (EMail.Replace("@", "").Length + 1 != EMail.Length)
            return false;
        // should be exactly one @ 
        return EMailValidationRegEx.IsMatch(EMail);
    }


}
