using Shop.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public partial class Customer : User
    {
        public int LoyaltyLevel { get; set; }

        internal string InternalNote { get; set; }

        public Customer()
        {
            LoyaltyLevel = 0;
        }

        public void UpgradeLoyalty()
        {
            LoyaltyLevel++;
        }
    }
}
