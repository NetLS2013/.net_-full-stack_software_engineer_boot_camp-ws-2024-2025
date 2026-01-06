namespace OrderLibrary.Item
{
    public sealed class HardwareItem : ItemBase
    {
        public string SerialNumber { get; }
        public decimal WeightKg { get; }
        public ItemSize Size { get; }

        public HardwareItem(string name, decimal price, decimal discount, string serialNumber, decimal weightKg, ItemSize size)
            : base(name, price, discount)
        {
            SerialNumber = serialNumber;
            WeightKg = weightKg;
            Size = size;
        }
    }
}
