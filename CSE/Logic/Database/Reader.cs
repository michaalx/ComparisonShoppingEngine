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
                //ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString
                ConnectionString = "Data Source=mssql6.gear.host;Initial Catalog=cse;User ID=cse;Password=Pr9O8fdOvG_!"
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

		public List<Tuple<DateTime, decimal>> ReadHistoryData(string productName, int storeName)
		{
			var history = new List<Tuple<DateTime, decimal>>();

			SqlCommand cmd = new SqlCommand("SELECT DISTINCT h.price, r.date, h.product, r.shopid " +
													"FROM history h, receipt r " +
													 "WHERE h.receiptid = r.id " +
													 "AND h.product = '" + productName +
													 "' AND r.shopid = '" + storeName + "';", con);
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    history.Add(Tuple.Create(reader.GetDateTime(1), reader.GetDecimal(0)));
                }
                return history;
            }
            catch (InvalidOperationException)
            {
                return new List<Tuple<DateTime, decimal>>() { new Tuple<DateTime, decimal>(new DateTime(2008, 5, 1, 8, 30, 52), 0) };
            }
			
		}
	}
}
