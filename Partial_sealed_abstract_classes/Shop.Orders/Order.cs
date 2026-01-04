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
    }
}
