using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public sealed class GroceryItem : ItemBase
    {
        public bool IsPerishable { get; set; }

        public GroceryItem(string name, decimal price, bool isPerishable)
        {
            Name = name;
            BasePrice = price;
            IsPerishable = isPerishable;
        }

        public override decimal GetNetPrice()
        {
            return ApplyDiscount(BasePrice, PromoDiscountPercent);
        }
    }
}
