using Logic.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Logic.Database
{
    public class Updater : IUpdater
    {
        private readonly IConfiguration _configuration;

        public Updater(IConfiguration configuration) => _configuration = configuration;

        public int UpdatePopularityRates(Receipt receipt)
        {
            var query = "UPDATE product SET Popularity=Popularity+@Nr WHERE ShopId=@Id AND Name=@ProductName";
            var store = (int)receipt.StoreName;
            try
            {
                var connectionString = _configuration["DatabaseConnectionString"];
                var listOfProducts = receipt.Products;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (var item in listOfProducts)
                        {
                            command.Parameters.AddWithValue("@Nr", item.Quantity);
                            command.Parameters.AddWithValue("@Id", store);
                            command.Parameters.AddWithValue("@ProductName", item.Name);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();

                        }
                    }
                }
                return 0;
            }
            catch (SqlException)
            {
                return -1;
            }
        }
    }
}
