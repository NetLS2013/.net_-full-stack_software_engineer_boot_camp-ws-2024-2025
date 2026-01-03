using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public abstract class ItemBase
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }

        // protected
        protected decimal SupplierDiscountPercent { get; set; }

        // internal
        internal decimal BackofficeDiscountPercent { get; set; }

        // protected internal
        protected internal decimal PromoDiscountPercent { get; set; }

        public decimal GetPublicPrice() => Price;

        // базова логіка, яку можуть використати нащадки
        protected decimal ApplyDiscount(decimal amount, decimal percent)
            => amount - (amount * percent / 100m);
    }
}
