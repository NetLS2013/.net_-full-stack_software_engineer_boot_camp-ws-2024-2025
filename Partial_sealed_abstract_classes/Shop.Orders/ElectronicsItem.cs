using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public sealed class ElectronicsItem : ItemBase
    {
        public int WarrantyMonths { get; set; }

        public ElectronicsItem(string name, decimal price, int warrantyMonths)
        {
            Name = name;
            BasePrice = price;
            WarrantyMonths = warrantyMonths;
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
