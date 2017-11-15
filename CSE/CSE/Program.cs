using System;
using System.Windows.Forms;
using CSE.FrontEnd;

using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

namespace CSE
{
    static class Program
    {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
			con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
				
			con.Open();
			SqlCommand cmd = new SqlCommand("Select * From Table_1 ", con);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				Console.WriteLine(reader.GetInt32(0).ToString() + " " + reader.GetString(1).ToString() + " " + reader.GetDecimal(2).ToString() + " " + reader.GetString(3).ToString() + " " + reader.GetDateTime(4).ToString() + "$");
			}
			reader.Close();
			con.Close();

				Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}