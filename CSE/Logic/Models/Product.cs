using System;

namespace Logic.Models
{
    public class Product : IComparable<Product>
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public Product(string name, decimal price)
        {
            StoreName(name);
            StorePrice(price);
        }
        public Product(string name, decimal price, int quantity)
        {
            StoreName(name);
            StorePrice(price);
            StoreQuantity(quantity);
        }
        private void StoreName(string name) => Name = name; 

        private void StorePrice(decimal price) => Price = price;

        private void StoreQuantity(int quantity) => Quantity = quantity;
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
