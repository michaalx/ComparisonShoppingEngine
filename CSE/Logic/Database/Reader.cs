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

		public Dictionary<decimal, DateTime> ReadHistoryData(Store storeName, string productName)
		{
			Dictionary<decimal, DateTime> history = new Dictionary<decimal, DateTime>();

			SqlCommand cmd = new SqlCommand("SELECT DISTINCT h.price, r.date" +
													"FROM history AS h, receipt AS r" +
													 "WHERE h.receiptid = r.id" +
													 "AND h.product = " + productName +
													 " AND r.shopid = " + storeName + ";", con);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				history.Add(reader.GetDecimal(0), reader.GetDateTime(1));
			}
			foreach (KeyValuePair<decimal, DateTime> e in history)
				Console.WriteLine(e.Key.ToString() + " " + e.Value.ToString());
			return history;
		}
	}
}
