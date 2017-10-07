using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite
{
    public partial class ArticlesPage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            ARep.DataSource = WebsiteArticle.All;
            ARep.DataBind();
        }
    }
}