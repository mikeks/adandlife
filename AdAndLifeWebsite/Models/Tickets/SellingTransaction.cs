﻿using AdAndLifeWebsite.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using VitalConnection.AAL.Builder.Model;

namespace AdAndLifeWebsite.Models.Tickets
{


	public class SellingTransaction : DbObject, IDbObject
    {
        public int Id { get; set; }
        public int EventId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
        public string RedeemCode { get; set; }

        //public bool IsTicketsAvaliable => TotalTicketCount - SoldTicketCount > 0;

        public void ReadFromDb(SqlDataReader rdr)
        {
            Id = (int)rdr["Id"];
			EventId = (int)rdr["EventId"];
			Name = (string)rdr["Name"];
			Email = (string)rdr["Email"];
			RedeemCode = (string)rdr["RedeemCode"];
        }

		public SellingTransaction(string name, string email)
		{
			Name = name;
			Email = email;
		}

		public SellingTransaction()
		{
		}

		public static SellingTransaction GetById(int id)
		{
			return ReadCollectionFromDb<SellingTransaction>("select * from ticket.Buyer where Id = " + id.ToString()).FirstOrDefault();
		}

		public void BeginSellingTransaction(SaleEvent sale, IEnumerable<Ticket> tickets)
		{

			var d = new DataTable();
			d.Columns.Add("Seat", typeof(String));
			foreach (var t in tickets)
			{
				d.Rows.Add(t.Seat);
			}

			ReadSql("ticket.BeginSellingTransaction", (cmd) =>
			{
				cmd.Parameters.AddWithValue("@eventId", sale.Id);
				cmd.Parameters.AddWithValue("@name", Name);
				cmd.Parameters.AddWithValue("@email", Email);
				cmd.Parameters.AddWithValue("@seats", d);
			}, (rdr) =>
			{
				Id = (int)rdr["Id"];
			});

		}

		private string GenerateRedeemCode()
		{
			var sb = new StringBuilder();
			string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
			for (int i = 0; i < 8; i++)
			{
				var idx = new Random().Next(chars.Length);
				sb.Append(chars[idx]);
			}
			return sb.ToString();
		}


		public void CompleteTransaction(string transactionCode)
		{
			var rcode = GenerateRedeemCode();
			ExecStoredProc("ticket.CompeteSellingTransaction", (cmd) =>
			{
				cmd.Parameters.AddWithValue("@transactionId", Id);
				cmd.Parameters.AddWithValue("@transactionCode", transactionCode);
				cmd.Parameters.AddWithValue("@redeemCode", rcode);
			});

		}


	}




}