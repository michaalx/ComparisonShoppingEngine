using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Metadata;
using System.Diagnostics;

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
				productList.Add(reader.GetString(0).Trim());
			}
			return productList;
		}

        public List<string> ReadOneStore(int storeId)
        {
            List<string> productList = new List<string>();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT name, shopid FROM product "
                                            + "WHERE shopid = '" + storeId + "';", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productList.Add(reader.GetString(0).Trim());
            }
            return productList;
        }

        public List<Tuple<string, decimal>> ReadForCheapest(Store store)
        {
            var products = new List<Tuple<string, decimal>>();
            //List<string> productList = new List<string>();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT p.name, p.price, p.shopid, s.name, s.id " +
                                                    "FROM product p, shop s " +
                                                    "WHERE s.name = '" + store.ToString() + 
                                                    "' AND s.id = p.shopid;", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Debug.WriteLine(reader.GetDecimal(1));
                products.Add(Tuple.Create(reader.GetString(0), reader.GetDecimal(1)));
            }
            return products;
        }

		public List<Tuple<DateTime, decimal>> ReadHistoryData(string productName, int storeName)
		{
			var history = new List<Tuple<DateTime, decimal>>();

			SqlCommand cmd = new SqlCommand("SELECT DISTINCT h.price, r.date, h.product, r.shopid " +
													"FROM history h, receipt r " +
													 "WHERE h.receiptid = r.id " +
													 "AND h.product = '" + productName +
													 "' AND r.shopid = '" + storeName + "';", con);
            
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                history.Add(Tuple.Create(reader.GetDateTime(1), reader.GetDecimal(0)));
            }
            return history;
			
		}
	}
}
