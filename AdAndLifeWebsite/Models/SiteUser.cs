using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AdAndLifeWebsite.Models
{

	public class SiteUser: DbObject, IDbObject
	{

		public string[] Access { get; set; }
		public string UserName { get; set; }
		private string Password { get; set; }

		public void ReadFromDb(SqlDataReader rdr)
		{
			Access = ((string)rdr["Access"]).ToLowerInvariant().Split(',');
			UserName = (string)rdr["UserName"];
			Password = (string)rdr["Password"];
		}

		//public static bool IsAdmin => HttpContext.Current.Session["admin"] != null;

		//public static void SetAdmin()
		//{
		//	HttpContext.Current.Session["admin"] = true;
		//}

		//public static void TestAdminAccess()
		//{
		//	if (!IsAdmin) HttpContext.Current.Response.Redirect("/Admin/Login.aspx", true);
		//}

		public static SiteUser CurrentUser => HttpContext.Current.Session["cuser"] as SiteUser;

		public static bool CheckAccess(string requiredAccess)
		{
			if (requiredAccess == null) return (CurrentUser != null);
			var a = requiredAccess.ToLowerInvariant();
			return (CurrentUser != null && (CurrentUser.Access.Contains(a) || CurrentUser.Access.Contains("all")));
		}

		public static void CheckPageAccess(string requiredAccess)
		{
			if (!CheckAccess(requiredAccess)) HttpContext.Current.Response.Redirect("/Admin/Login.aspx", true);
		}

		public static void Logout()
		{
			HttpContext.Current.Session["cuser"] = null;
		}

		public static SiteUser Login(string username, string password)
		{
			var user = ReadCollectionFromDb<SiteUser>("DoLogin", (cmd) => cmd.Parameters.AddWithValue("@userName", username)).FirstOrDefault();

			if (user == null) return null;

			//var sha1 = new SHA1CryptoServiceProvider();
			//var data = Encoding.ASCII.GetBytes(password);
			//var sha1data = sha1.ComputeHash(data);
			//var hashedPassword = Convert.ToBase64String(sha1data);

			if (user.Password != password) return null;

			HttpContext.Current.Session["cuser"] = user;

			return user;
		}

		public static IEnumerable<SiteUser> GetAllUsers()
		{
			return ReadCollectionFromDb<SiteUser>("select * from AdminLogin");
		}

	}
}