using AdAndLifeWebsite.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace AdAndLifeWebsite.Models.Articles.Entities
{


	public class WebsiteArticle : DbObject, IDbObject
	{

		public int Id { get; private set; }
		public DateTime Created { get; private set; }
		public string Name { get; private set; }
		public string Author { get; private set; }
		public ArticleRubric Rubric { get; private set; }
		public int IssueYear { get; private set; }
		public short IssueNumber { get; private set; }
		public string Txt { get; private set; }

		public string SummaryText { get; private set; }

		public string IssueNumberAndYear
		{
			get
			{
				if (IssueNumber == 0) return "";
				return $"№{IssueNumber} ({IssueYear}) |";
			}
		}

		private void PopulateSummaryText()
		{
			var s = Txt.Substring(Txt.IndexOf("<p>"));

			s = s.Replace("&nbsp;", " ");
			while (s.Contains("  ")) s = s.Replace("  ", " ");

			s = Regex.Replace(s, "<.*?>", " ").Substring(0, 400);

			var p = s.LastIndexOf(". "); 
			if (p < 100) p = s.LastIndexOf(" ");
			if (p < 100) p = 300;
			s = s.Substring(0, p) + "...";


			SummaryText = s;
		}

        public void ReadFromDb(SqlDataReader rdr)
        {
            Id = (int)rdr["Id"];
            Name = (string)rdr["Name"];
			Author = (string)ResolveDbNull(rdr["Author"]);
			Created = (DateTime)rdr["Created"];
			var rubricId = (int?)ResolveDbNull(rdr["RubricId"]);
			Rubric = rubricId == null ? null : ArticleRubric.GetById(rubricId.Value);
			IssueYear = (int)rdr["IssueYear"];
			IssueNumber = (short)rdr["IssueNumber"];
			var rawText = (string)rdr["txt"];
			Txt = Regex.Replace(rawText, "ArticleImages\\/(\\d+).jpg", $"ArticleImage.ashx?a={Id}&n=$1");
			PopulateSummaryText();
			
		}



        public static WebsiteArticle GetById(int id)
        {
			return All.FirstOrDefault((x) => x.Id == id);
        }


        public static IEnumerable<WebsiteArticle> All
        {
            get
            {
				var articles = (WebsiteArticle[])HttpContext.Current.Cache.Get("articles");
				if (articles == null)
				{
					articles = ReadCollectionFromDb<WebsiteArticle>("select * from [WebsiteArticle]");
					HttpContext.Current.Cache.Insert("articles", articles, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration);
				}
				return articles;
            }
        }


		public static byte[] GetImage(int articleId, int num)
		{
			byte[] data = null;
			ReadSql($"select data from WebsiteArticleImage where ArticleId = {articleId} and Num = {num}", (rdr) =>
			{
				data = (byte[])rdr["data"];
			});
			return data;
		}

        
    }




    }