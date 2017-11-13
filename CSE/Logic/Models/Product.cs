namespace Logic.Models
{
    struct Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        //   public void SetName(string name)  => Name = name;
        // public void SetPrice(decimal price) => Price = price;
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
