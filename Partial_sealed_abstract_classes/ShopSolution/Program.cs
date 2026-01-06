using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Users;
using Shop.Orders;

namespace ShopSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            PremiumUser user = new PremiumUser();
            user.Email = "premium@mail.com";
            user.SetPersonalDiscount(10);
            user.SetPremiumExtraDiscount(7);

            Order order = new Order();
            order.SetSeasonalDiscount(3);
            order.SetManagerDiscount(2);

            Item generic = new Item("Generic item", 120m);
            generic.SetSupplierDiscount(3);
            generic.SetPromoDiscount(7);

            generic.SetSize(new ItemSize(30m, 20m, 10m));

            ElectronicsItem tv = new ElectronicsItem("TV", 1000m, 24);
            tv.SetSupplierDiscount(10);
            tv.SetPromoDiscount(5);

            GroceryItem milk = new GroceryItem("Milk", 50m, true);
            milk.SetPromoDiscount(2);

            ServiceItem cleaning = new ServiceItem("Cleaning", 200m, 3);
            cleaning.SetPromoDiscount(10);

            order.AddItem(tv);
            order.AddItem(generic);
            order.AddItem(milk);
            order.AddItem(cleaning);
            order.SetStatus(OrderStatus.Created);
            order.DeliveryType = DeliveryType.Courier;


            void PrintOrderSummary(IOrderTotalCalculator totalCalc, IShippingCalculator shippingCalc)
            {
                decimal total = totalCalc.CalculateTotal();
                decimal delivery = shippingCalc.CalculateDeliveryCost();
                decimal grandTotal = total + delivery;

                System.Console.WriteLine("Items total: " + total);
                System.Console.WriteLine("Delivery: " + delivery);
                System.Console.WriteLine("Grand total: " + grandTotal);
            }
            IOrderTotalCalculator totalCalculator = order;
            IShippingCalculator shippingCalculator = order;


            Console.WriteLine("User: " + user);
            Console.WriteLine("Generic size: " + generic.Size + " | Volume: " + generic.Size.VolumeCm3 + " cm3");
            Console.WriteLine("Total user discount: " + user.GetTotalDiscount() + "%");
            Console.WriteLine("Status: " + order.Status);
            Console.WriteLine("DeliveryType: " + order.DeliveryType);
            PrintOrderSummary(totalCalculator, shippingCalculator);

            Console.ReadLine();
        }
    }
}
