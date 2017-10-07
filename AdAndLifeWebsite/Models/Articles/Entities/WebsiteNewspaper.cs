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

namespace AdAndLifeWebsite.Models.Articles.Entities
{

    public enum NewspaperTypeEnum
    {
        AdAndLifePhila = 0,
        JewishLife = 1,
        AdAndLifeBaltimore = 2
    }

    public class WebsiteNewspaper : DbObject, IDbObject
    {
        public int Id { get; set; }
        public NewspaperTypeEnum NewspaperType { get; set; }
        public int Year { get; set; }
        public int Number { get; set; }
        public string Url { get; set; }

        public string NewspaperImageTypeUrl => "Img/newspaper_" + (NewspaperType == NewspaperTypeEnum.AdAndLifePhila ? "adandlife" : "jewish") + ".png";

        public string NewspaperTypeDescr
        {
            get
            {
                switch (NewspaperType)
                {
                    case NewspaperTypeEnum.AdAndLifePhila:
                        return "Реклама и Жизнь - Филадельфия";
                    case NewspaperTypeEnum.AdAndLifeBaltimore:
                        return "Реклама и Жизнь - Балтимор";
                    case NewspaperTypeEnum.JewishLife:
                        return "Еврейская Жизнь";
                    default:
                        return "";
                }
            }
        }

        public void ReadFromDb(SqlDataReader rdr)
        {
            NewspaperType = (NewspaperTypeEnum)(byte)rdr["NewspaperType"];
            Id = (int)rdr["Id"];
            Year = (int)rdr["Year"];
            Number = (byte)rdr["Number"];
            Url = (string)rdr["Url"];
        }

        private static WebsiteNewspaper[] _all;

        public static WebsiteNewspaper[] All
        {
            get
            {
                if (_all == null)
                {
                    _all = ReadCollectionFromDb<WebsiteNewspaper>("select * from [WebsiteNewspapers] order by Year desc, Number desc, NewspaperType");
                }
                return _all;
            }
        }

        

        internal void Save()
        {
            ExecStoredProc("SaveWebsiteNewspaper", (cmd) =>
            {
                cmd.Parameters.AddWithValue("@newspaperType", NewspaperType);
                cmd.Parameters.AddWithValue("@year", Year);
                cmd.Parameters.AddWithValue("@number", Number);
                cmd.Parameters.AddWithValue("@url", Url);
            });
            _all = null;
        }

        internal static void Delete(int id)
        {
            ExecSQL("delete from WebsiteNewspapers where Id = " + id);
            _all = null;
        }


    }




}