using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Logic.Metadata;
using System.Configuration;

namespace Logic.Database
{
    public class Reader : IReader
    {
	private SqlConnection _con;
	private SqlDataReader _reader;
    private readonly IConfiguration _configuration;

    public Reader(IConfiguration configuration) => _configuration = configuration;

		public void OpenConnection()
		{
            _con = new SqlConnection
            {
                ConnectionString = _configuration["DatabaseConnectionString"]
            };
            _con.Open();
                                    
            //try
			//{
			//	_con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
			//	_con.Open();
			//}
			//catch (ConnectionFailedException)
			//{
			//	throw new ConnectionFailedException(_con.ConnectionString);
			//}
		}

			public void CloseConnection()
		{
			_reader.Close();
			_con.Close();
		}

		public IEnumerable<string> ReadProductData()
		{
			List<string> productList = new List<string>();
			SqlCommand cmd = new SqlCommand("SELECT DISTINCT name FROM product", _con);
			_reader = cmd.ExecuteReader();
			while (_reader.Read())
			{
				productList.Add(_reader.GetString(0).Trim());
			}
			return productList;
		}

        public List<string> ReadOneStore(int storeId)
        {
            List<string> productList = new List<string>();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT name, shopid FROM product "
                                            + "WHERE shopid = @SN;", _con);

			cmd.Parameters.AddWithValue("@SN", storeId);

			_reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                productList.Add(_reader.GetString(0).Trim());
            }
            return productList;
        }

        public List<Tuple<string, decimal>> ReadForCheapest(Store store)
        {
            var products = new List<Tuple<string, decimal>>();
            //List<string> productList = new List<string>();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT p.name, p.price, p.shopid, s.name, s.id " +
                                                    "FROM product p, shop s " +
                                                    "WHERE s.name = @SN " + 
                                                    "AND s.id = p.shopid;", _con);

			cmd.Parameters.AddWithValue("@SN", store.ToString());

			_reader = cmd.ExecuteReader();
            while (_reader.Read())
            {
                //Debug.WriteLine(reader.GetDecimal(1));
                products.Add(Tuple.Create(_reader.GetString(0), _reader.GetDecimal(1)));
            }
            return products;
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

			_reader = cmd.ExecuteReader();
			while (_reader.Read())
			{
				history.Add(Tuple.Create(_reader.GetDateTime(1), _reader.GetDecimal(0)));
			}
			return history;
		}

        public List<Tuple<string, short, decimal, string>> ReadPopularity()
        {
            var query = 
                "SELECT x.name, x.popularity, x.price, s.name " +
                "FROM product x, shop s " +
                "WHERE x.shopid = s.id " +
                "ORDER BY x.popularity DESC;";
            var listOfPopularProducts = new List<Tuple<string,short, decimal, string>>();
            SqlCommand sqlCommand = new SqlCommand(query,_con);
            _reader = sqlCommand.ExecuteReader();
            while (_reader.Read())
            {
                if (listOfPopularProducts.Count < 5)
                {
                    listOfPopularProducts.Add(Tuple.Create(_reader.GetString(0), _reader.GetInt16(1), _reader.GetDecimal(2),_reader.GetString(3)));
                }
            }
            return listOfPopularProducts;
        }
	}
}
