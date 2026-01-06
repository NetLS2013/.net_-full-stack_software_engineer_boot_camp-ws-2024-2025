namespace OrderLibrary.Item
{
    public sealed class HardwareItem : ItemBase
    {
        public string SerialNumber { get; }
        public decimal WeightKg { get; }

        public HardwareItem(string name, decimal price, decimal discount, string serialNumber, decimal weightKg)
            : base(name, price, discount)
        {
            SerialNumber = serialNumber;
            WeightKg = weightKg;
        }
    }
}
