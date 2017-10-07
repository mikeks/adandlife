using AdAndLifeWebsite.Models;
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
    public partial class ArchivePage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            repArchiveALPhila.DataSource = WebsiteNewspaper.All.Where((x) => x.NewspaperType == NewspaperTypeEnum.AdAndLifePhila);
            repArchiveALPhila.DataBind();

            repArchiveALBaltimore.DataSource = WebsiteNewspaper.All.Where((x) => x.NewspaperType == NewspaperTypeEnum.AdAndLifeBaltimore);
            repArchiveALBaltimore.DataBind();

            repArchiveJL.DataSource = WebsiteNewspaper.All.Where((x) => x.NewspaperType == NewspaperTypeEnum.JewishLife);
            repArchiveJL.DataBind();

            if (Request["del"] != null && SiteUser.IsAdmin)
            {
                WebsiteNewspaper.Delete(int.Parse(Request["del"]));
                Response.Redirect("archive.aspx");
            }

            if (IsPostBack)
            {
                try
                { 
                    var np = new WebsiteNewspaper()
                    {
                        NewspaperType = (NewspaperTypeEnum)int.Parse(ddArticleType.SelectedValue),
                        Number = int.Parse(tbNumber.Text),
                        Year = int.Parse(tbYear.Text),
                        Url = tbUrl.Text
                    };
                    np.Save();
                    Response.Redirect("archive.aspx");
                }
                catch (Exception)
                {
                    ErrorDiv.Visible = true;
                }


            }

        }

    }
}