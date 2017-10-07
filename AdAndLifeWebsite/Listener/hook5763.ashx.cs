using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AdAndLifeWebsite.Listener
{
	/// <summary>
	/// Summary description for hook5763
	/// </summary>
	public class hook5763 : IHttpHandler
	{

		string GetRequestData(HttpContext context)
		{
			var log = new StringBuilder();
			for (var i = 0; i <= context.Request.Form.AllKeys.Length - 1; i++)
			{
				string key = context.Request.Form.AllKeys[i];
				string value = context.Request.Form[key];
				if (i > 0) log.Append("<br>");
				log.AppendFormat("{0} = {1}", key, value);
			}
			return log.ToString();
		}



		public void ProcessRequest(HttpContext context)
		{
			var s = GetRequestData(context);
			if (context.Application["AalLog"] != null)
				context.Application["AalLog"] += "<br><br><br>" + s;
			else
				context.Application.Add("AalLog", s);
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}