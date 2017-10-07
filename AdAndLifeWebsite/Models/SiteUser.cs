using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdAndLifeWebsite.Models
{
    public class SiteUser
    {

        public static bool IsAdmin => HttpContext.Current.Session["admin"] != null;

        public static void SetAdmin()
        {
            HttpContext.Current.Session["admin"] = true;
        }

        public static void TestAdminAccess()
        {
            if (!IsAdmin) HttpContext.Current.Response.Redirect("/Admin/Login.aspx", true);
        }

    }
}