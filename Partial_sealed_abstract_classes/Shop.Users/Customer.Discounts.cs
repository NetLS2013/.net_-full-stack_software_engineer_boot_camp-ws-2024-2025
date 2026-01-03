using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public partial class Customer
    {
        protected internal decimal PersonalDiscountPercent { get; set; }

        public void SetPersonalDiscount(decimal percent)
        {
            if (percent < 0) percent = 0;
            if (percent > 50) percent = 50;
            PersonalDiscountPercent = percent;
        }
    }

}
