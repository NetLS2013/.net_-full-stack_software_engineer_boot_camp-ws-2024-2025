using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Users
{
    public class Customer : User
    {
        public int LoyaltyLevel { get; set; }

        // internal
        internal string InternalNote { get; set; }

        public void UpgradeLoyalty() => LoyaltyLevel++;

        public void PrintDebugInfo()
        {
            // Тут доступ є, бо PasswordHash = protected
            Console.WriteLine($"[Customer] HasPasswordHash: {HasPasswordHash()}");
        }
    }
}
