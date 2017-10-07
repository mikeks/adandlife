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

namespace AdAndLifeWebsite.Models
{


    public class TicketsSale : DbObject, IDbObject
    {
        public int Id { get; set; } = 0;
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        //public int TotalTicketCount { get; set; }
        //public int SoldTicketCount { get; set; }
        //public string PaypalButtonCode { get; set; }
        public string UrlName { get; set; }
        public bool IsAvaliable { get; set; }

        //public bool IsTicketsAvaliable => TotalTicketCount - SoldTicketCount > 0;

        public void ReadFromDb(SqlDataReader rdr)
        {
            Id = (int)rdr["Id"];
            EventName = (string)rdr["EventName"];
            EventDescription = (string)rdr["EventDescription"];
            //TotalTicketCount = (int)rdr["TotalTickets"];
            //SoldTicketCount = (int)rdr["SoldTickets"];
            //PaypalButtonCode = (string)rdr["PaypalButtonCode"];
            IsAvaliable = (bool)rdr["IsAvaliable"];
            UrlName = (string)rdr["UrlName"];
        }

        private static TicketsSale[] _all;

        public static IEnumerable<TicketsSale> AllForSale => All.Where((x) => x.IsAvaliable);

        public static TicketsSale[] All
        {
            get
            {
                if (_all == null)
                {
                    //_all = ReadCollectionFromDb<TicketsSale>("GetTicketsSales");
                    _all = ReadCollectionFromDb<TicketsSale>("select * from ticket.SaleEvent order by Created");
                }
                return _all;
            }
        }

        public static TicketsSale GetById(int id)
        {
            return All.FirstOrDefault((x) => x.Id == id);
        }

        public static TicketsSale GetByUrl(string url)
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