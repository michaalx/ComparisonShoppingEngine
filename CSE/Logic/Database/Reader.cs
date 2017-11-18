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

		public IEnumerable<string> ReadData(string query)
		{
			List<string> list = new List<string>();
			SqlCommand cmd = new SqlCommand(query, con);
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				list.Add(reader.Get(0).ToString());
			}
			return list;
		}
	}
}
