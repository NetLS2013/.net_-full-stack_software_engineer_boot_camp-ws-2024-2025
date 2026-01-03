using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public sealed class Item : ItemBase
    {
        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void SetSupplierDiscount(decimal percent)
        {
            // SupplierDiscountPercent = protected
            SupplierDiscountPercent = percent;
        }

        public decimal GetNetPriceForOrder()
        {
            // приклад: спочатку постачальник, потім промо
            var p = ApplyDiscount(Price, SupplierDiscountPercent);
            p = ApplyDiscount(p, PromoDiscountPercent);
            return p;
        }
    }
}
