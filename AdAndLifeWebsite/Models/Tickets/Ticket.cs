using AdAndLifeWebsite.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite.Models.Tickets
{


	public class Ticket : DbObject, IDbObject
    {
        public int Id { get; set; }
		public int EventId { get; set; }
		public int TicketTypeId { get; set; }
		public string Seat { get; set; }

        //public bool IsTicketsAvaliable => TotalTicketCount - SoldTicketCount > 0;

        public void ReadFromDb(SqlDataReader rdr)
        {
            Id = (int)rdr["Id"];
			EventId = (int)rdr["EventId"];
			TicketTypeId = (int)rdr["TicketTypeId"];
			Seat = (string)rdr["Seat"];
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

		public static IEnumerable<Ticket> GetTicketsForTransaction(SellingTransaction trans)
		{
			return ReadCollectionFromDb<Ticket>("select * from ticket.Tickets where TransactionId = " + trans.Id.ToString());
		}

	}




}