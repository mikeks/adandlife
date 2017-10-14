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


    public class SaleEvent : DbObject, IDbObject
    {
		public decimal HandlingFee = 3.5M;
        public int Id { get; set; } = 0;
        public int LocationId { get; set; }
        public EventLocation Location { get; private set; }
        public string EventName { get; set; }
        public string EventNameEng { get; set; }
        public string EventDescription { get; set; }

		public string EventImage { get; set; }
        public DateTime EventDate { get; set; }
        //public int TotalTicketCount { get; set; }
        //public int SoldTicketCount { get; set; }
        //public string PaypalButtonCode { get; set; }
        public string UrlName { get; set; }
        public bool IsAvaliable { get; set; }

		//public bool IsTicketsAvaliable => TotalTicketCount - SoldTicketCount > 0;

		public IEnumerable<TicketType> Codes => TicketType.ForEvent(this);

		public IEnumerable<Ticket> Tickets => Ticket.GetAvaliableTickets(this);

		public void ReadFromDb(SqlDataReader rdr)
        {
            Id = (int)rdr["Id"];
            EventName = (string)rdr["EventName"];
			EventNameEng = (string)rdr["EventNameEng"];
			EventDescription = (string)rdr["EventDescription"];

			EventImage = (string)rdr["EventImage"];
			LocationId = (int)rdr["LocationId"];
			Location = EventLocation.GetById(LocationId);

			EventDate = (DateTime)rdr["EventDate"];

			IsAvaliable = (bool)rdr["IsAvaliable"];
            UrlName = (string)rdr["UrlName"];
        }

        private static SaleEvent[] _all;

        public static IEnumerable<SaleEvent> AllForSale => All.Where((x) => x.IsAvaliable);

        public static SaleEvent[] All
        {
            get
            {
                if (_all == null)
                {
                    //_all = ReadCollectionFromDb<TicketsSale>("GetTicketsSales");
                    _all = ReadCollectionFromDb<SaleEvent>("select * from ticket.SaleEvent order by Created");
                }
                return _all;
            }
        }

        public static SaleEvent GetById(int id)
        {
            return All.FirstOrDefault((x) => x.Id == id);
        }

        public static SaleEvent GetByUrl(string url)
        {
            return All.FirstOrDefault((x) => x.UrlName == url);
        }

        internal void Save()
        {
            ExecStoredProc("SaveTicketsSale", (cmd) =>
            {
                if (Id != 0) cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@eventName", EventName);
                cmd.Parameters.AddWithValue("@eventDescription", EventDescription);
                //cmd.Parameters.AddWithValue("@totalTickets", TotalTicketCount);
                //cmd.Parameters.AddWithValue("@paypalButtonCode", PaypalButtonCode);
                cmd.Parameters.AddWithValue("@isAvaliable", IsAvaliable);
                cmd.Parameters.AddWithValue("@urlName", UrlName);
            });
            _all = null;
        }

        internal static void Delete(int id)
        {
            ExecSQL("delete from TicketsSale where Id = " + id);
            _all = null;
        }


    }




}