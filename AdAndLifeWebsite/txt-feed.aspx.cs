using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdAndLifeWebsite.Models;

namespace AdAndLifeWebsite
{
	public partial class TxtFeed : System.Web.UI.Page
	{
		public int AdId;
		public string AdText;

		protected void Page_Load(object sender, EventArgs e)
		{
			DbObject.ReadSql("GetRss", null, (rdr) =>
			{
				AdId = (int)rdr["ClassifiedId"];
				AdText = (string)rdr["text"];
			});
		}
	}
}