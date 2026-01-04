using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public sealed class Item : ItemBase
    {
        public ItemSize Size { get; private set; }

        public Item(string name, decimal price)
        {
            Name = name;
            BasePrice = price;
            Size = new ItemSize(0m, 0m, 0m);
        }

        public void SetSize(ItemSize size)
        {
            Size = size;
        }

        public void SetSupplierDiscount(decimal percent)
        {
            SupplierDiscountPercent = percent;
        }

        public void SetPromoDiscount(decimal percent)
        {
            PromoDiscountPercent = percent;
        }

        public override decimal GetNetPrice()
        {
            decimal p = ApplyDiscount(BasePrice, SupplierDiscountPercent);
            p = ApplyDiscount(p, PromoDiscountPercent);
            return p;
        }
    }
}

