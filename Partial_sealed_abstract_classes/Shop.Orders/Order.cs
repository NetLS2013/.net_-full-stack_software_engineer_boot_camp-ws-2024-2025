using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public sealed class Order : OrderBase
    {
        public void SetManagerDiscount(decimal percent)
        {
            ManagerDiscountPercent = percent;
        }

        public void SetSeasonalDiscount(decimal percent)
        {
            SeasonalDiscountPercent = percent;
        }

        public override decimal CalculateTotal()
        {
            decimal sum = 0m;

            foreach (var item in Items)
            {
                sum += item.GetNetPrice();
            }

            sum = sum - (sum * SeasonalDiscountPercent / 100m);
            sum = sum - (sum * ManagerDiscountPercent / 100m);

            return sum;
        }

        public override decimal CalculateDeliveryCost()
        {
            decimal delivery = 50m;

            foreach (var item in Items)
            {
                delivery += 10m;
                Item generic = item as Item;
                if (generic != null)
                {
                    decimal extra = generic.Size.VolumeCm3 / 1000m;
                    delivery += extra;
                }
            }

            return delivery;
        }
    }
}
