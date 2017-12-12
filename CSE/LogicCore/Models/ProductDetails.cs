using System;
using System.Collections.Generic;
using System.Text;

namespace LogicCore.Models
{
    class ProductDetails
    {
        public string Name { get; }
        public decimal Price { get; }
        public DateTime Timestamp { get; }
        public int UserId { get; }
        public ProductDetails(string name, decimal price, DateTime timestamp, int userId)
        {
            Name = name;
            Price = price;
            Timestamp = timestamp;
            UserId = userId;
        }
    }
}
