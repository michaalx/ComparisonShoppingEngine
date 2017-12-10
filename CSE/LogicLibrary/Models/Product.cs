using LogicLibrary.Metadata;
using System;

namespace LogicLibrary.Models
{
    public class Product : IComparable<Product>
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public short Quantity { get; private set; }
        public string Store { get; private set; }
        public Product(string name, decimal price)
        {
            SetName(name);
            SetPrice(price);
        }
        public Product(string name, decimal price, short quantity)
        {
            SetName(name);
            SetPrice(price);
            SetQuantity(quantity);
        }

        public Product(string name, decimal price, short quantity, string store)
        {
            SetName(name);
            SetPrice(price);
            SetQuantity(quantity);
            SetStore(store);
        }
        private void SetName(string name) => Name = name; 

        private void SetPrice(decimal price) => Price = price;

        private void SetQuantity(short quantity) => Quantity = quantity;

        private void SetStore(string store) => Store = store;

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
