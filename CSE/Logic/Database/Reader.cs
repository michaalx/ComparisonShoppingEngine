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
		private System.Data.SqlClient.SqlConnection _con = new SqlConnection();
		private SqlDataReader reader;

		public void OpenConnection()
		{
			try
			{
				_con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
				_con.Open();
			}
			catch (Exception e)
			{
				throw new ConnectionFailedException(_con.ConnectionString);
			}
		}

		public void CloseConnection()
		{
			reader.Close();
			_con.Close();
		}

		public IEnumerable<string> ReadProductData()
		{
			List<string> productList = new List<string>();
			SqlCommand cmd = new SqlCommand("SELECT DISTINCT name FROM product", _con);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				productList.Add(reader.GetString(0));
			}
			return productList;
		}

		public List<Tuple<DateTime, decimal>> ReadHistoryData(string productName, int storeName)
		{
			var history = new List<Tuple<DateTime, decimal>>();

			SqlCommand cmd = new SqlCommand("SELECT DISTINCT h.price, r.date, h.product, r.shopid " +
													"FROM history h, receipt r " +
													"WHERE h.receiptid = r.id " +
													"AND h.product = @PN AND r.shopid = @SN;", _con);

			cmd.Parameters.AddWithValue("@PN", productName);
			cmd.Parameters.AddWithValue("@SN", storeName);

			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				history.Add(Tuple.Create(reader.GetDateTime(1), reader.GetDecimal(0)));
			}
			return history;
		}
	}
}
