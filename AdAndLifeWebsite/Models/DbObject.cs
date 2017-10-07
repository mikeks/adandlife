﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VitalConnection.AAL.Builder.Model
{

    public class ConnectionProblemException : Exception { }


    public class DbObject
    {



        protected static SqlConnection GetConnection()
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
            try
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
            catch (ConnectionProblemException e)
            {
            }
        }

        private static void _exec(string storedProcName, Action<SqlCommand> addParAction, CommandType cmdType)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var cmd = new SqlCommand(storedProcName, conn) { CommandType = cmdType };
                    addParAction?.Invoke(cmd);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (ConnectionProblemException)
            {
            }
            catch (Exception e)
            {
                Directory.CreateDirectory(@"c:\NewspaperBuilderErrors");
                var dt = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
                var s = 
$@"Stored proc: {storedProcName}
Error: {e.Message}
Inner: {e.InnerException?.Message}
Stack: {e.StackTrace}
";
                File.WriteAllText($@"c:\NewspaperBuilderErrors\{dt}.log", s);
            }
        }

        protected static void ExecStoredProc(string storedProcName, Action<SqlCommand> addParAction)
        {
            _exec(storedProcName, addParAction, CommandType.StoredProcedure);
        }

        protected static void ExecSQL(string storedProcName, Action<SqlCommand> addParAction = null)
        {
            _exec(storedProcName, addParAction, CommandType.Text);
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
