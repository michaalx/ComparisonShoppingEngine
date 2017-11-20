using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Metadata;

namespace Logic.Database
{
	public class Reader
	{
		private System.Data.SqlClient.SqlConnection con;
		private SqlDataReader reader;

		public void OpenConnection()
		{
			con = new System.Data.SqlClient.SqlConnection
			{
				ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString
			};
			con.Open();
		}

		public void CloseConnection()
		{
			reader.Close();
			con.Close();
		}

		public IEnumerable<string> ReadProductData()
		{
			List<string> productList = new List<string>();
			SqlCommand cmd = new SqlCommand("SELECT DISTINCT name FROM product", con);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				productList.Add(reader.GetString(0));
			}
			return productList;
		}

		public List<Tuple<decimal, DateTime>> ReadHistoryData(int storeName, string productName)
		{
			var history = new List<Tuple<decimal, DateTime>>();

			SqlCommand cmd = new SqlCommand("SELECT DISTINCT h.price, r.date, h.product, r.shopid " +
													"FROM history h, receipt r " +
													 "WHERE h.receiptid = r.id " +
													 "AND h.product = '" + productName +
													 "' AND r.shopid = '" + storeName + "';", con);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				history.Add(Tuple.Create(reader.GetDecimal(0), reader.GetDateTime(1)));
			}
			return history;
			//FOR TESTING
			//var reader = new Reader();
			//int store = (int)Store.IKI;
			//reader.OpenConnection();
			//var asd = reader.ReadHistoryData(store, "Pienas");
			//reader.CloseConnection();
			//foreach (Tuple<decimal, DateTime> e in asd)
			//Console.WriteLine(e.Item1.ToString() + " " + e.Item2.ToString());
		}
	}
}
