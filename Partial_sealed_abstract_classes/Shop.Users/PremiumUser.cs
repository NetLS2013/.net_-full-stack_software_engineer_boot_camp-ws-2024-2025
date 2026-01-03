using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public sealed class PremiumUser : Customer
    {
        public decimal PremiumExtraDiscountPercent { get; private set; }

        public PremiumUser()
        {
            PremiumExtraDiscountPercent = 5m;
        }

        public decimal GetTotalUserDiscount()
        {
            // бачимо PersonalDiscountPercent, бо воно protected internal і ми нащадок
            return PersonalDiscountPercent + PremiumExtraDiscountPercent;
        }

        public void SetPremiumExtraDiscount(decimal percent)
        {
            if (percent < 0) percent = 0;
            if (percent > 30) percent = 30;
            PremiumExtraDiscountPercent = percent;
        }
    }
}
