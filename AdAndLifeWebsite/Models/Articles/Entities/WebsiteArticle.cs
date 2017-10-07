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
    public class WebsiteArticle : DbObject, IDbObject
    {

        public int Id { get; set; }
        public string Name { get; set; }
        //public string ImageName { get; set; }
        //private byte[] ImageToSave { get; set; }

        private string ImageFolder
        {
            get
            {
                return HttpContext.Current.Server.MapPath("~/ArticleImages/" + Id + "/");
            }
        }

        public void SaveImage(byte[] rawRata)
        {
            if (!Directory.Exists(ImageFolder)) Directory.CreateDirectory(ImageFolder);

            using (var img = Image.FromStream(new MemoryStream(rawRata)))
            {
                var img2 = img.Width > 800 ? Utility.ResizeImage(img, 800) : img;

                int i = 0;
                while (File.Exists(ImageFolder + i + ".jpg"))
                {
                    i++;
                }
                img2.Save(ImageFolder + i + ".jpg");
            }
        }

        public IEnumerable<string> GetImagesUrls()
        {
            if (!Directory.Exists(ImageFolder)) return new string[0];
            var images = Directory.GetFiles(ImageFolder, "*.jpg");
            
            return images.Select((x) => "http://" + HttpContext.Current.Request.Url.Host + "/ArticleImages/" + Id + "/" + Path.GetFileName(x));
        }





        //public List<WebsiteImage> ArticleImages
        //{
        //    get
        //    {

        //        var aa = new List<WebsiteImage>();

        //        ReadSql($"select * from WebsiteImage where articleId = {Id}", (rdr) =>
        //        {
        //            var img = new WebsiteImage();
        //            img.ReadFromDb(rdr);
        //            aa.Add(img);
        //        });

        //        return aa;

        //    }
        //}


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
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@txt", Txt);

                //if (ImageToSave != null && ImageToSave.Length > 0)
                //{
                //    cmd.Parameters.AddWithValue("@imageName", ImageName);
                //    cmd.Parameters.Add(new SqlParameter("@imageData", System.Data.SqlDbType.VarBinary, ImageToSave.Length) { Value = ImageToSave });

                //}

            });
            _all = null;
        }

        internal static void Delete(int articleId)
        {
            ExecSQL("delete WebsiteArticle where id = " + articleId);
            _all = null;
        }
    }




    }