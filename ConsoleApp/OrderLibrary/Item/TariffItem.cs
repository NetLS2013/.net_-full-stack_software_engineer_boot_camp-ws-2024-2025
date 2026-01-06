namespace OrderLibrary.Item
{
    public class TariffItem : ItemBase
    {
        public int SpeedMbps { get; private set; }
        public int TrafficLimitGb { get; private set; }
        protected int MinContractTermMonths { get; private set; }


        public TariffItem(string name, decimal price, decimal discount, int speed, int limit, int minTermMonth =12)
            : base(name, price, discount)
        {
            SpeedMbps = speed;
            TrafficLimitGb = limit;
            MinContractTermMonths = minTermMonth; 
        }


        public decimal CalculateCancellationFee(int monthsUsed)
        {
            if (monthsUsed <= MinContractTermMonths)
            {
                int monthsLeft = MinContractTermMonths - monthsUsed;
                return (CalculateCurrentPrice() * monthsLeft) * 0.5m;
            }
            return 0;
        }
    }
}
