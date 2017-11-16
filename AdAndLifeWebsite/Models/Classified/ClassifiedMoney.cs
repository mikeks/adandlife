using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdAndLifeWebsite.Models.Classified
{

	public class ClassifiedMoney : DbObject, IDbObject
	{

		public int Id { get; private set; }
		public int? PhilaId { get; private set; }
		public int? BaltimoreId { get; private set; }
		public string Text { get; private set; }
		public decimal Price { get; private set; }
		public DateTime Created { get; private set; }
		public DateTime? PromotionExpirationDate { get; set; }


		public void ReadFromDb(SqlDataReader rdr)
		{
			Id = (int)rdr["Id"];
			PhilaId = (int?)ResolveDbNull(rdr["PhilaId"]);
			BaltimoreId = (int?)ResolveDbNull(rdr["BaltimoreId"]);
			Text = (string)rdr["AdText"];
			Price = (decimal)rdr["Price"];
			Created = (DateTime)rdr["AdCreated"];
			PromotionExpirationDate = (DateTime?)ResolveDbNull(rdr["AdExpirationDate"]);
        }

		public static IEnumerable<ClassifiedMoney> All => ReadCollectionFromDb<ClassifiedMoney>("select * from ClassifiedMoney");

	}
}
