using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdAndLifeWebsite.Models
{

    public class ConnectionProblemException : Exception { }


    public class DbObject
    {



        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch
            {
                conn.Dispose();
                throw new ConnectionProblemException();
            }
        }

        protected static void ReadSql(string sql, Action<SqlDataReader> f)
        {
            using (var conn = GetConnection())
            {
                var cmd = new SqlCommand(sql, conn);
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        f(rdr);
                    }
                }
            }
        }

        public static void ReadSql(string storedProcName, Action<SqlCommand> addParAction, Action<SqlDataReader> f, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = GetConnection())
            {
				var cmd = new SqlCommand(storedProcName, conn) { CommandType =  commandType };
				addParAction?.Invoke(cmd);
				using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        f(rdr);
                    }
                }
            }
        }

        private static void _exec(string storedProcName, Action<SqlCommand> addParAction, CommandType cmdType)
        {
            using (var conn = GetConnection())
            {
                var cmd = new SqlCommand(storedProcName, conn) { CommandType = cmdType };
                addParAction?.Invoke(cmd);
                cmd.ExecuteNonQuery();
            }
        }

		public static void ExecStoredProc(string storedProcName, Action<SqlCommand> addParAction)
        {
            _exec(storedProcName, addParAction, CommandType.StoredProcedure);
        }

        public static void ExecSQL(string storedProcName, Action<SqlCommand> addParAction = null)
        {
            _exec(storedProcName, addParAction, CommandType.Text);
        }

		protected static T[] ReadCollectionFromDb<T>(string storedProcName, Action<SqlCommand> addParAction) where T : IDbObject, new()
		{
			List<T> ss = new List<T>();
			ReadSql(storedProcName, addParAction, (rdr) =>
			{
				var itm = new T();
				itm.ReadFromDb(rdr);
				ss.Add(itm);
			});
			return ss.ToArray();
		}

		protected static T[] ReadCollectionFromDb<T>(string sql) where T : IDbObject, new()
        {
            List<T> ss = new List<T>();
            ReadSql(sql, (rdr) =>
            {
                var itm = new T();
                itm.ReadFromDb(rdr);
                ss.Add(itm);
            });
            return ss.ToArray();
        }

        protected static T[] ReadCollectionFromDb<T>(string sql, Func<T> factory) where T : IDbObject
        {
            List<T> ss = new List<T>();
            ReadSql(sql, (rdr) =>
            {
                var itm = factory();
                itm.ReadFromDb(rdr);
                ss.Add(itm);
            });
            return ss.ToArray();
        }

        protected object ResolveDbNull(object o, object def = null)
        {
            return o is DBNull ? def : o;
        }

    }
}
