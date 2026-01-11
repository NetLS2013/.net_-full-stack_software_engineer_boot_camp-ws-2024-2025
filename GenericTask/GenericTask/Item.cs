namespace GenericTask
{

    public class Item
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Manufacturer { get; private set; }


        public Item(string name, string manufacturer, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Manufacturer = manufacturer;
        }

    }
}
