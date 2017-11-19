using System;

namespace Logic.Models
{
    public struct Product : IComparable<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public int CompareTo(Product product)
        {
            return string.Compare(product.Name, Name);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
