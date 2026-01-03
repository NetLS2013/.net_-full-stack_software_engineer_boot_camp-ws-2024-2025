using System;
using System.Xml.Linq;

namespace OrdersLibrary
{
    public abstract class OrderBase
    {
        public int OrderNumber { get; set; }

        protected decimal DiscountPercent { get; set; }
        private protected decimal InternalDiscount { get; set; }

        protected OrderBase(int number)
        {
            OrderNumber = number;
            DiscountPercent = 10;
            InternalDiscount = 5;
        }

        public abstract void ShowDiscounts();
    }

    public sealed class Order : OrderBase
    {
        public Order(int number) : base(number) { }

        public override void ShowDiscounts()
        {
            Console.WriteLine("=== Order Discounts ===");
            Console.WriteLine($"Discount: {DiscountPercent}%");
            Console.WriteLine($"Internal Discount: {InternalDiscount}%");
        }
    }

    public abstract class ItemBase
    {
        public string ItemName { get; set; }

        protected decimal WholesalePrice { get; set; }

        private protected decimal InternalCost { get; set; }

        protected ItemBase(string name, decimal price, decimal cost)
        {
            ItemName = name;
            WholesalePrice = price;
            InternalCost = cost;
        }
        public abstract void ShowPrices();
    }

    public sealed class ElectronicsItem : ItemBase
    {
        public int WarrantyMonths { get; set; }

        public ElectronicsItem(string name)
            : base(name, 1200, 900)
        {
            WarrantyMonths = 24;
        }

        public override void ShowPrices()
        {
            Console.WriteLine($"Electronics: {ItemName}");
            Console.WriteLine($"Price: {WholesalePrice}");
            Console.WriteLine($"Warranty: {WarrantyMonths} months");
        }
    }
    public sealed class FoodItem : ItemBase
    {
        public DateTime ExpirationDate { get; set; }

        public FoodItem(string name)
            : base(name, 50, 30)
        {
            ExpirationDate = DateTime.Now.AddDays(7);
        }

        public override void ShowPrices()
        {
            Console.WriteLine($"Food: {ItemName}");
            Console.WriteLine($"Price: {WholesalePrice}");
            Console.WriteLine($"Expires: {ExpirationDate:d}");
        }
    }
}
