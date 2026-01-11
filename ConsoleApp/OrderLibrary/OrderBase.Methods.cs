using OrderLibrary.Item;

namespace OrderLibrary
{
    public abstract partial class OrderBase : IPriceCalculator, IDeliveryCalculator
    {
        public decimal CalculateRawPrice()
        {
            decimal sum = 0;
            foreach (var item in Items)
            {
                sum += item.Price;
            }

            return sum;
        }

        public decimal CalculateDiscount()
        {
            return CalculateRawPrice() - CalculateTotalPrice();
        }

        public decimal CalculateTotalPrice()
        {
            decimal sum = 0;
            foreach (var item in Items)
            {
                sum += item.CalculateCurrentPrice();
            }

            return sum - (sum * DiscountRate);
        }


        public decimal CalculateDeliveryCost(string destinationCity)
        {
            decimal totalWeight = 0;

            foreach (var item in Items)
            {
                if (item is HardwareItem p)
                {
                    totalWeight += p.WeightKg;
                }
            }

            decimal baseCost = 50, costPerKg = 10;
            decimal cost = baseCost + totalWeight * costPerKg;


            if (destinationCity != "Ivano-Frankivsk")
            {
                cost *= 2;
            }

            return cost;
        }

        public string GetDeliveryDateStatus()
        {
            if (!DeliveryDate.HasValue)
            {
                return "Pending scheduling (Date not set)";
            }
            else
            {
                return $"Scheduled for: {DeliveryDate.Value.ToShortDateString()}";
            }
        }
    }
}
