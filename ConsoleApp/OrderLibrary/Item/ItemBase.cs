namespace OrderLibrary.Item
{
    public class ItemBase
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        protected decimal DiscountRate { get; set; }


        public ItemBase(string name, decimal price, decimal discount)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            DiscountRate = discount;
        }

        public decimal CalculateCurrentPrice()
        {
            return Price - (Price * DiscountRate);
        }
    }
}
