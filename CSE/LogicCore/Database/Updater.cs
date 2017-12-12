using LogicCore.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace LogicCore.Database
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

        public int UpdatePrices(Receipt receipt)
        {
            try
            {
                var query = "UPDATE Product SET Price=@NewPrice WHERE Name=@ProductName AND ShopId=@Id AND Price > @NewPrice";
                var listOfProducts = receipt.Products;
                var store = (int)receipt.StoreName;
                var connectionString = _configuration["DatabaseConnectionString"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach (var item in listOfProducts)
                        {
                            command.Parameters.AddWithValue("@NewPrice", item.Price);
                            command.Parameters.AddWithValue("@ProductName", item.Name);
                            command.Parameters.AddWithValue("@Id", store);
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
