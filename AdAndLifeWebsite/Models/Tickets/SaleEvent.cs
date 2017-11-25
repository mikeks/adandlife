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


    public class SaleEvent : DbObject, IDbObject
    {
		public decimal HandlingFee = 3.5M;
        public int Id { get; set; } = 0;
        public int LocationId { get; set; }
        public EventLocation Location { get; private set; }
        public string EventName { get; set; }
        public string EventNameEng { get; set; }
		public string EventDescription { get; set; } = "";
		public string EventImage { get; set; }
		public DateTime EventDate { get; set; } = DateTime.Today;
        public string UrlName { get; set; }
        public bool IsAvaliable { get; set; }
        public byte OurShare { get; set; }

		public IEnumerable<TicketType> Codes => TicketType.ForEvent(this);

		public IEnumerable<Ticket> AvaliableTickets => Ticket.GetAvaliableTickets(this);
		public IEnumerable<Ticket> AllTickets => Ticket.GetAllTickets(this);

		public IEnumerable<Ticket> SoldTickets => AllTickets.Where((x) => x.BuyerName != null && x.PurchaseDate != null);

		public decimal TotalSoldAmount => SoldTickets.Sum((x) => x.Price);
		public decimal OurShareUSD => TotalSoldAmount * OurShare / 100;

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
			OurShare = (byte)rdr["OurShare"];

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
                    _all = ReadCollectionFromDb<SaleEvent>("select * from ticket.SaleEvent order by EventDate");
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
			_all = null;
			ExecStoredProc("ticket.SaveSaleEvent", (cmd) =>
            {
                if (Id != 0) cmd.Parameters.AddWithValue("@id", Id);
				cmd.Parameters.AddWithValue("@locationId", LocationId);
				cmd.Parameters.AddWithValue("@eventName", EventName);
				cmd.Parameters.AddWithValue("@eventNameEng", EventNameEng);
				cmd.Parameters.AddWithValue("@eventDescription", EventDescription);
				cmd.Parameters.AddWithValue("@eventImage", EventImage);
				cmd.Parameters.AddWithValue("@eventDate", EventDate);
				cmd.Parameters.AddWithValue("@urlName", UrlName);
				cmd.Parameters.AddWithValue("@isAvaliable", IsAvaliable);
				cmd.Parameters.AddWithValue("@ourShare", OurShare);
            });
        }


		private string ImageFolder
		{
			get
			{
				return HttpContext.Current.Server.MapPath("~/ArticleImages/events/");
			}
		}

		public void SaveImage(byte[] rawRata)
		{

			using (var img = Image.FromStream(new MemoryStream(rawRata)))
			{
				if (img.Width < 400)
				{
					throw new Exception("Размер афиши слишком маленький. Требуется хотя бы 400 пикселей в ширину.");
				}

				var img2 = Utility.ResizeImage(img, 400);

				var fn = ImageFolder + UrlName + ".jpg";
				if (File.Exists(fn))
				{
					File.Delete(fn);
				}
				img2.Save(fn);

				EventImage = UrlName + ".jpg";

			}
		}

		public IEnumerable<SellingTransaction> GetTransactions()
		{
			return SellingTransaction.GetByEventId(Id);
		}


	}




}