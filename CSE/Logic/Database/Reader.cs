using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database
{
	public class Reader
	{
		private List<string> _productDB = new List<string>();
		int count = 0;

		public Reader() { }

		public void Read()
		{
			System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
			con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

			con.Open();
			SqlCommand cmd = new SqlCommand("SELECT DISTINCT name FROM product", con);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				_productDB.Add(reader.GetString(0));
				Console.WriteLine(_productDB[count]);
				count++;
				//Console.WriteLine(reader.GetInt32(0).ToString() + " " + reader.GetString(1).ToString() + " " + reader.GetDecimal(2).ToString() + " " + reader.GetString(3).ToString() + " " + reader.GetDateTime(4).ToString() + "$");
			}
			reader.Close();
			con.Close();
		}
	}
}
