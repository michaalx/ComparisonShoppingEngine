using System;
using System.Collections.Generic;

namespace CSE.BackEnd
{
    public struct ProductDetails
    {
       // public List<Product> Products { get; }
        public string Name { get; }
        public DateTime Timestamp { get; }
        public decimal Price { get; }
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