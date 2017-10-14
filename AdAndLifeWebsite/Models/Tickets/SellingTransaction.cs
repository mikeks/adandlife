using AdAndLifeWebsite.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite.Models.Tickets
{


	public class SellingTransaction : DbObject, IDbObject
    {
        public int Id { get; set; }
        public int EventId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
        public string RedeemCode { get; set; }
        public DateTime? RedeemDateTime { get; set; }

        //public bool IsTicketsAvaliable => TotalTicketCount - SoldTicketCount > 0;

        public void ReadFromDb(SqlDataReader rdr)
        {
            Id = (int)rdr["Id"];
			EventId = (int)rdr["EventId"];
			Name = (string)rdr["Name"];
			Email = (string)rdr["Email"];
			RedeemCode = (string)ResolveDbNull(rdr["RedeemCode"]);
			RedeemDateTime = (DateTime?)ResolveDbNull(rdr["RedeemDateTime"]);
        }

		public SellingTransaction(string name, string email)
		{
			Name = name;
			Email = email;
		}

		public SellingTransaction()
		{
		}

		public static SellingTransaction GetById(int id)
		{
			return ReadCollectionFromDb<SellingTransaction>("select * from ticket.SellTransaction where Id = " + id.ToString()).FirstOrDefault();
		}

		public static SellingTransaction GetByRedeemCode(string redeemCode)
		{
			return ReadCollectionFromDb<SellingTransaction>("select * from ticket.SellTransaction where RedeemCode = '" + redeemCode + "'").FirstOrDefault();
		}

		public void TicketRedeemed()
		{
			ExecSQL("update ticket.SellTransaction set RedeemDateTime = GETDATE() where Id = " + Id);
		}

		public void SaveDigitalTicket(string html)
		{
			ExecSQL("update ticket.SellTransaction set DigitalTicketHtml = @html where Id = @id", (cmd) =>
			{
				cmd.Parameters.AddWithValue("@id", Id);
				cmd.Parameters.AddWithValue("@html", html);
			});
		}

		public void BeginSellingTransaction(SaleEvent sale, IEnumerable<Ticket> tickets)
		{

			var d = new DataTable();
			d.Columns.Add("Seat", typeof(String));
			foreach (var t in tickets)
			{
				d.Rows.Add(t.Seat);
			}

			ReadSql("ticket.BeginSellingTransaction", (cmd) =>
			{
				cmd.Parameters.AddWithValue("@eventId", sale.Id);
				cmd.Parameters.AddWithValue("@name", Name);
				cmd.Parameters.AddWithValue("@email", Email);
				cmd.Parameters.AddWithValue("@seats", d);
			}, (rdr) =>
			{
				Id = (int)rdr["Id"];
			});

		}

		private string GenerateRedeemCode()
		{
			var sb = new StringBuilder();
			string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
			int secondsSinceMidnight = Convert.ToInt32(DateTime.Now.Subtract(DateTime.Today).TotalSeconds);
			Random rnd = new Random(secondsSinceMidnight);
			for (int i = 0; i < 8; i++)
			{
				var idx = rnd.Next(chars.Length);
				sb.Append(chars[idx]);
			}
			return sb.ToString();
		}


		public void CompleteTransaction(string transactionCode)
		{
			var rcode = GenerateRedeemCode();
			ExecStoredProc("ticket.CompeteSellingTransaction", (cmd) =>
			{
				cmd.Parameters.AddWithValue("@transactionId", Id);
				cmd.Parameters.AddWithValue("@transactionCode", transactionCode);
				cmd.Parameters.AddWithValue("@redeemCode", rcode);
			});

		}


	}




}