using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public abstract class ItemBase
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }

        protected decimal SupplierDiscountPercent { get; set; }
        protected internal decimal PromoDiscountPercent { get; set; }

        protected ItemBase()
        {
            Name = "";
        }

        public decimal GetPublicPrice()
        {
            return BasePrice;
        }

        protected decimal ApplyDiscount(decimal price, decimal percent)
        {
            return price - (price * percent / 100m);
        }

        public abstract decimal GetNetPrice();
    }
}
