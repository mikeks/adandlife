using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite.Models.Articles.Entities
{
	public class WebsiteArticle : DbObject, IDbObject
	{

		public int Id { get; set; }
		public string Name { get; set; }

		private string _txt;
		public string Txt
		{
			get
			{
				if (_txt == null)
				{
					ReadSql($"select txt from WebsiteArticle where id = {Id}", (rdr) =>
					{
						Txt = (string)rdr["txt"];
					});
				}
				return _txt;
			}
			set
			{
				_txt = value;
			}
		}

		public void ReadFromDb(SqlDataReader rdr)
		{
			Id = (int)rdr["Id"];
			Name = (string)rdr["Name"];
		}

		private static Dictionary<int, WebsiteArticle> _all;


		private static void ReadAll()
		{
			if (_all == null)
			{
				var aa = ReadCollectionFromDb<WebsiteArticle>("select Id, Name from [WebsiteArticle]");
				_all = new Dictionary<int, WebsiteArticle>();
				foreach (var a in aa)
				{
					_all.Add(a.Id, a);
				}
			}
		}

		public static WebsiteArticle GetById(int id)
		{
			ReadAll();
			return _all.ContainsKey(id) ? _all[id] : null;
		}

		public static IEnumerable<WebsiteArticle> All
		{
			get
			{
				ReadAll();
				return _all.Values;
			}
		}

		internal void Save()
		{
			ExecStoredProc("SaveWebsiteArticle", (cmd) =>
			{
				if (Id > 0) cmd.Parameters.AddWithValue("id", Id);
				cmd.Parameters.AddWithValue("Name", Name);
				cmd.Parameters.AddWithValue("Txt", Txt);
			});
			_all = null;
		}
	}




}