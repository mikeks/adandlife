using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdAndLifeWebsite.Models.Articles.Entities
{
	public class ArticleRubric : DbObject, IDbObject
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public void ReadFromDb(SqlDataReader rdr)
		{
			Id = (int)rdr["Id"];
			Name = (string)rdr["Name"];
		}

		public override string ToString()
		{
			return Name;
		}

		private static void ReadAllFromDb()
		{
			_all = ReadCollectionFromDb<ArticleRubric>("select * from ArticleRubric");
		}

		public static ArticleRubric[] _all;
		public static ArticleRubric[] All
		{
			get
			{
				if (_all == null) ReadAllFromDb();
				return _all;
			}
		}

		public static ArticleRubric GetById(int id)
		{
			return All.FirstOrDefault((x) => x.Id == id);
		}

	}
}