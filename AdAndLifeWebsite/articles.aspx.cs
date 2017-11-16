using AdAndLifeWebsite.Models.Articles.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdAndLifeWebsite
{
    public partial class ArticlesPage : System.Web.UI.Page
    {

		protected void Page_Init(object sender, EventArgs e)
		{
			(Master as MainMaster).PageTitle = "Статьи";
			(Master as MainMaster).MetaDescription = "Читать статьи авторов, опубликованных в газетах Реклама и Жизнь и Еврейская Жизнь";
		}


		protected void Page_Load(object sender, EventArgs e)
        {

            ARep.DataSource = WebsiteArticle.All;
            ARep.DataBind();
        }
    }
}