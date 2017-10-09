using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite.Listener
{
	/// <summary>
	/// Summary description for hook5763
	/// </summary>
	public class hook5763 : IHttpHandler
	{

		string GetRequestData(HttpContext context)
		{
			using (var reader = new StreamReader(context.Request.InputStream))
			{
				return reader.ReadToEnd();
			}
		}


		public void ProcessRequest(HttpContext context)
		{
			var s = GetRequestData(context);

			DbObject.ExecStoredProc("ticket.LogTransaction", (cmd) => cmd.Parameters.AddWithValue("@data", s));

			//if (context.Application["AalLog"] != null)
			//	context.Application["AalLog"] += "<br><br><br>" + s;
			//else
			//	context.Application.Add("AalLog", s);
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