using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public class Order : OrderBase
    {
        public void SetManagerDiscount(decimal percent) => ManagerDiscountPercent = percent;

        public override decimal CalculateTotal()
        {
            decimal sum = 0m;

            foreach (var i in Items)
            {
                // Якщо це наш Item, беремо нетто-ціну з внутрішніми знижками
                if (i is Item item)
                    sum += item.GetNetPriceForOrder();
                else
                    sum += i.GetPublicPrice();
            }

            // далі знижки ордера (не видно юзеру напряму)
            sum = sum - (sum * SeasonalDiscountPercent / 100m);
            sum = sum - (sum * ManagerDiscountPercent / 100m);

            return sum;
        }
    }
}
