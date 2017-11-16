using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdAndLifeWebsite.Models.Admin
{

	public class MikeMoney : DbObject, IDbObject
	{

		public int Id { get; private set; }
		public DateTime Created { get; set; }
		public decimal Amount { get; set; }

		public void ReadFromDb(SqlDataReader rdr)
		{
			Id = (int)rdr["Id"];
			Created = (DateTime)rdr["Created"];
			Amount = (decimal)rdr["Amount"];
        }

		public static IEnumerable<MikeMoney> All => ReadCollectionFromDb<MikeMoney>("select * from MikeMoney");

		public void Save()
		{
			ExecSQL("insert MikeMoney (Created, Amount) values (@created, @amount)", (cmd) =>
			{
				cmd.Parameters.AddWithValue("@created", Created);
				cmd.Parameters.AddWithValue("@amount", Amount);
			});
		}

		public void Delete()
		{
			ExecSQL("delete MikeMoney where Id = @id", (cmd) =>
			{
				cmd.Parameters.AddWithValue("@id", Id);
			});
		}

	}
}
