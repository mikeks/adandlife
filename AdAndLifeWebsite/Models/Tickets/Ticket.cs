using AdAndLifeWebsite.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace AdAndLifeWebsite.Models.Tickets
{


	public class Ticket : DbObject, IDbObject
    {
        public int Id { get; set; }
		public int EventId { get; set; }
		public int TicketTypeId { get; set; }
		public string Seat { get; set; }
		public DateTime? LockedUntil { get; set; }
		public DateTime? PurchaseDate { get; set; }
		public int? TransactionId { get; set; }

		public SellingTransaction Transaction
		{
			get
			{
				if (!TransactionId.HasValue) return null;
				return SellingTransaction.GetById(TransactionId.Value);
			}
		}
		
		public string BuyerName
		{
			get
			{
				if (Transaction == null) return null;
				return Transaction.Name;
			}
		}

		public void ReadFromDb(SqlDataReader rdr)
        {
            Id = (int)rdr["Id"];
			EventId = (int)rdr["EventId"];
			TicketTypeId = (int)rdr["TicketTypeId"];
			Seat = (string)rdr["Seat"];
			LockedUntil = (DateTime?)ResolveDbNull(rdr["LockedUntil"]);
			PurchaseDate = (DateTime?)ResolveDbNull(rdr["PurchaseDate"]);
			TransactionId = (int?)ResolveDbNull(rdr["TransactionId"]);
        }

		//public void Lock()
		//{
		//	ExecStoredProc("ticket.LockTicket", (cmd) => cmd.Parameters.AddWithValue("@id", Id));
		//}

		public decimal Price => TicketType.All.First((x) => x.Id == TicketTypeId).Price;

        public static IEnumerable<Ticket> GetAvaliableTickets(SaleEvent ev)
        {
            return ReadCollectionFromDb<Ticket>("ticket.GetAvaliableTickets", (cmd) => cmd.Parameters.AddWithValue("@eventId", ev.Id));
		}

        public static IEnumerable<Ticket> GetAllTickets(SaleEvent ev)
        {
            return ReadCollectionFromDb<Ticket>("ticket.GetAllTickets", (cmd) => cmd.Parameters.AddWithValue("@eventId", ev.Id));
		}

		public static IEnumerable<Ticket> GetTicketsForTransaction(SellingTransaction trans)
		{
			return ReadCollectionFromDb<Ticket>("select * from ticket.Tickets where TransactionId = " + trans.Id.ToString());
		}

		public static void CreateNew(int eventId, decimal price, string seat)
		{
			ExecStoredProc("[ticket].[AddTicket]", (cmd) =>
			{
				cmd.Parameters.AddWithValue("@eventId", eventId);
				cmd.Parameters.AddWithValue("@price", price);
				cmd.Parameters.AddWithValue("@seat", seat);
			});
		}

		public static void DeleteTicket(int eventId, string seat)
		{
			ExecStoredProc("[ticket].[DeleteTicket]", (cmd) =>
			{
				cmd.Parameters.AddWithValue("@eventId", eventId);
				cmd.Parameters.AddWithValue("@seat", seat);
			});
		}


	}




}