﻿using AdAndLifeWebsite.Classes;
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


	public class TicketType : DbObject, IDbObject
    {
        public int Id { get; set; }
		public int EventId { get; set; }
        public decimal Price { get; set; }

        //public bool IsTicketsAvaliable => TotalTicketCount - SoldTicketCount > 0;

        public void ReadFromDb(SqlDataReader rdr)
        {
            Id = (int)rdr["Id"];
			EventId = (int)rdr["EventId"];
			Price = (decimal)rdr["Price"];
        }

        private static TicketType[] _all;

        public static TicketType[] All
        {
            get
            {
                if (_all == null)
                {
                    //_all = ReadCollectionFromDb<TicketsSale>("GetTicketsSales");
                    _all = ReadCollectionFromDb<TicketType>("select * from ticket.TicketType");
                }
                return _all;
            }
        }

        public static IEnumerable<TicketType> ForEvent(SaleEvent ev)
        {
            return All.Where((x) => x.EventId == ev.Id);
        }


    }




}