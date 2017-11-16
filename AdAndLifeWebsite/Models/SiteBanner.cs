using AdAndLifeWebsite.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AdAndLifeWebsite.Models
{

	public class SiteBanner : DbObject, IDbObject
	{

		public int Id { get; private set; }
		public string Name { get; set; }
		public string ImageFilename { get; set; }
		public int PositionRight { get; set; }
		public int PositionHomepage { get; set; }
		public decimal Price { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime Created { get; set; }

		public string FullscreenFilename => ImageFilename + "-fullscreen.jpg";
		public string HomepageFilename => ImageFilename + "-homepage.jpg";
		public string RightColumnFilename => ImageFilename + ".jpg";


		public void ReadFromDb(SqlDataReader rdr)
		{
			Id = (int)rdr["Id"];
			Name = (string)rdr["Name"];
			ImageFilename = (string)rdr["ImageFilename"];
			PositionRight = (byte)rdr["PositionRight"];
			PositionHomepage = (byte)rdr["PositionHomepage"];
			Price = (decimal)rdr["Price"];
			EndDate = (DateTime)rdr["EndDate"];
			Created = (DateTime)rdr["Created"];
        }

		public static IEnumerable<SiteBanner> All => ReadCollectionFromDb<SiteBanner>("select * from SiteBanner");

		public static IEnumerable<SiteBanner> BannersForHomepage => All.Where((x) => x.PositionHomepage != 0 && x.EndDate > DateTime.Now).OrderBy((x) => x.PositionHomepage);
		public static IEnumerable<SiteBanner> BannersForRightColumn => All.Where((x) => x.PositionRight != 0 && x.EndDate > DateTime.Now).OrderBy((x) => x.PositionRight);

		public static SiteBanner GetById(int id)
		{
			return All.FirstOrDefault((x) => x.Id == id);
		}

		public void Save()
		{
			ExecStoredProc("SaveSiteBanner", (cmd) =>
			{
				if (Id != 0) cmd.Parameters.AddWithValue("@id", Id);
				cmd.Parameters.AddWithValue("@name", Name);
				cmd.Parameters.AddWithValue("@imageFilename", ImageFilename);
				cmd.Parameters.AddWithValue("@positionRight", PositionRight);
				cmd.Parameters.AddWithValue("@positionHomepage", PositionHomepage);
				cmd.Parameters.AddWithValue("@price", Price);
				cmd.Parameters.AddWithValue("@endDate", EndDate);
			});
		}

		public void Delete()
		{
			ExecSQL("delete SiteBanner where Id = @id", (cmd) =>
			{
				cmd.Parameters.AddWithValue("@id", Id);
			});
		}

		private string ImageFolder
		{
			get
			{
				return HttpContext.Current.Server.MapPath("~/ArticleImages/banners/");
			}
		}

		
		private void SaveImage(Image img, string filename)
		{
			if (File.Exists(filename))
			{
				File.Delete(filename);
			}
			img.Save(filename);
		}


		public void SaveImage(byte[] rawRata, string imageFilename)
		{

			ImageFilename = imageFilename;

			using (var img = Image.FromStream(new MemoryStream(rawRata)))
			{
				if (img.Width < 600)
				{
					throw new Exception("Размер баннера слишком маленький. Требуется хотя бы 600 пикселей в ширину.");
				}

				SaveImage(img, ImageFolder + FullscreenFilename);
				SaveImage(Utility.ResizeImage(img, 600), ImageFolder + HomepageFilename);
				SaveImage(Utility.ResizeImage(img, 300), ImageFolder + RightColumnFilename);
			}
		}

	}
}
