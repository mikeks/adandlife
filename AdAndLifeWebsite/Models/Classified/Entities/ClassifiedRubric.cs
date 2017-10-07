using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalConnection.AAL.Builder.Model
{
	public class ClassifiedRubric : DbObject, IDbObject
	{

		public int Id { get; private set; }
		public string Name { get; private set; }
		public string ImageFilename { get; private set; }
		public int SortOrder { get; private set; }

        public List<ClassifiedAd> Ads { get; set; } = new List<ClassifiedAd>();

		public ClassifiedRubric()
		{

		}

		public ClassifiedRubric(string name)
		{
			Name = name;
		}

		public void ReadFromDb(SqlDataReader rdr)
		{
			Id = (int)rdr["Id"];
			Name = (string)rdr["Name"];
			SortOrder = (byte)rdr["Sort"];
            ImageFilename = (string)rdr["ImageFilename"];
        }

		private static ClassifiedRubric[][] _all;

        private static void ReadAllFromDb()
        {
            _all = new ClassifiedRubric[2][];
            _all[0] = ReadCollectionFromDb<ClassifiedRubric>("select * from ClassifiedRubric");
            _all[1] = ReadCollectionFromDb<ClassifiedRubric>("select * from ClassifiedRubricBaltimore");
        }

        public static ClassifiedRubric GetById(int state, int id)
		{
            if (_all == null) ReadAllFromDb();
			return _all[state].FirstOrDefault((x) => x.Id == id);
		}

        public static void ReloadAllFromDb()
        {
            _all = null;
        }


        public static ClassifiedRubric[][] All => _all;
		

		public override string ToString()
		{
			return Name;
		}

	}
}
