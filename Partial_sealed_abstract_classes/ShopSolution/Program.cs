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
            Console.WriteLine("User ballance: " + user.Balance);
            string addmoney = user.AddBalance(500m);
            Console.WriteLine(addmoney);

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


            bool PrintOrderSummaryAndPay(IOrderPriceCalculator priceCalc, IOrderTotalCalculator totalCalc, IShippingCalculator shippingCalc)
            {
                decimal price = priceCalc.CalculatePrice();
                decimal total = totalCalc.CalculateTotal(price);
                decimal delivery = shippingCalc.CalculateDeliveryCost();
                decimal grandTotal = total + delivery;

                System.Console.WriteLine("Items price: " + price);
                System.Console.WriteLine("Items total: " + total);
                System.Console.WriteLine("Delivery: " + delivery);
                System.Console.WriteLine("Grand total: " + grandTotal);
                bool payForOrder = user.PayAmount(grandTotal);
                return payForOrder;
            }
            IOrderPriceCalculator priceCalculator = order;
            IOrderTotalCalculator totalCalculator = order;
            IShippingCalculator shippingCalculator = order;


            Console.WriteLine("User: " + user);
            Console.WriteLine("Generic size: " + generic.Size + " | Volume: " + generic.Size.VolumeCm3 + " cm3");
            Console.WriteLine("Total user discount: " + user.GetTotalDiscount() + "%");
            Console.WriteLine("Status: " + order.Status);
            Console.WriteLine("DeliveryType: " + order.DeliveryType);
            bool isSuccesfullPay = PrintOrderSummaryAndPay(priceCalculator, totalCalculator, shippingCalculator);
            if (isSuccesfullPay)
            {
                Console.WriteLine("Payment successful! New user balance: " + user.Balance);
                order.SetStatus(OrderStatus.Paid);
            }

            bool isSuccesfullDelivery = order.DeliverOrder();
            if (isSuccesfullDelivery)
            {
                Console.WriteLine("Order delivered! Status: " + order.Status);
            }

            Console.ReadLine();
        }
    }
}
