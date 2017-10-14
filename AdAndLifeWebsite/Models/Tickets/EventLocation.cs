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


	public class EventLocation : DbObject, IDbObject
    {
        public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

		public void ReadFromDb(SqlDataReader rdr)
        {
            Id = (int)rdr["Id"];
            Code = (string)rdr["LocationCode"];
			Name = (string)rdr["Name"];
			Address = (string)rdr["Address"];
        }

        private static EventLocation[] _all;

        public static EventLocation[] All
        {
            get
            {
                if (_all == null)
                {
                    _all = ReadCollectionFromDb<EventLocation>("select * from ticket.EventLocation");
                }
                return _all;
            }
        }

        public static EventLocation GetById(int Id)
        {
            return All.FirstOrDefault((x) => x.Id == Id);
        }


    }




}