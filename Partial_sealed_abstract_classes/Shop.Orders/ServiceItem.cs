using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public sealed class ServiceItem : ItemBase
    {
        public int Hours { get; set; }

        public ServiceItem(string name, decimal pricePerHour, int hours)
        {
            Name = name;
            BasePrice = pricePerHour;
            Hours = hours;
        }

        public void SetPromoDiscount(decimal percent)
        {
            PromoDiscountPercent = percent;
        }

        public override decimal GetNetPrice()
        {
            decimal total = BasePrice * Hours;
            total = ApplyDiscount(total, PromoDiscountPercent);
            return total;
        }
    }
}
