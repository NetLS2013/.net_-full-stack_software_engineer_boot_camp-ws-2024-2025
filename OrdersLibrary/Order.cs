using System;

namespace OrdersLibrary
{
    public class OrderBase
    {
        public int OrderNumber { get; set; }

        protected decimal DiscountPercent { get; set; }

        private protected decimal InternalDiscount { get; set; }

        public OrderBase(int orderNumber)
        {
            OrderNumber = orderNumber;
            DiscountPercent = 10;
            InternalDiscount = 5;
        }
    }

    public class Order : OrderBase
    {
        public Order(int orderNumber) : base(orderNumber) {}

        public void ShowDiscounts()
        {
            Console.WriteLine($"Discount: {DiscountPercent}%");
            Console.WriteLine($"Internal Discount: {InternalDiscount}%");
        }
    }

    public class ItemBase
    {
        public string ItemName { get; set; }

        protected decimal WholesalePrice { get; set; }

        private protected decimal InternalCost { get; set; }

        public ItemBase(string name)
        {
            ItemName = name;
            WholesalePrice = 100;
            InternalCost = 80;
        }
    }

    public class Item : ItemBase
    {
        public Item(string name) : base(name) { }

        public void ShowPrices()
        {
            Console.WriteLine($"Wholesale price: {WholesalePrice}");
            Console.WriteLine($"Internal cost: {InternalCost}");
        }
    }
}
