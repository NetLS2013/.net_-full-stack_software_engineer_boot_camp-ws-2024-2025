using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Users;
using Shop.Orders;

namespace ShopSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer
            {
                Email = "test@mail.com",
                LoyaltyLevel = 1
            };

            customer.SetPasswordHash("HASH123");
            customer.PrintDebugInfo();

            var item1 = new Item("Keyboard", 1000m);
            item1.SetSupplierDiscount(10);      // protected доступний через метод нащадка
            item1.PromoDiscountPercent = 5;     // protected internal не доступний напряму

            var order = new Order();
            order.AddItem(item1);

            order.SeasonalDiscountPercent = 3;  // protected internal не доступний напряму 
            
            order.SetManagerDiscount(2);

            var total = order.CalculateTotal();
            Console.WriteLine($"Customer: {customer}");
            Console.WriteLine($"Total: {total}");

            Console.ReadLine();
        }
    }
}
