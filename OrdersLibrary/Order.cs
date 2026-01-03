using System;
using System.Xml.Linq;

namespace OrdersLibrary
{
    public interface IPricedItem
    {
        decimal GetPrice();
    }

    public interface IDeliverable
    {
        decimal GetDeliveryCost();
    }
    public struct Dimensions
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double? Height { get; set; }

        public Dimensions(double l, double w, double? h)
        {
            Length = l;
            Width = w;
            Height = h;
        }

        public override string ToString()
        {
            return Height.HasValue
                ? $"{Length} x {Width} x {Height.Value} cm"
                : $"{Length} x {Width} cm";
        }
    }
    public abstract class OrderBase
    {
        public int OrderNumber { get; set; }

        protected decimal DiscountPercent { get; set; }
        private protected decimal InternalDiscount { get; set; }

        protected readonly List<IPricedItem> pricedItems = new();
        protected readonly List<IDeliverable> deliverables = new();

        protected OrderBase(int number)
        {
            OrderNumber = number;
            DiscountPercent = 10;
            InternalDiscount = 5;
        }
        public void AddItem(IPricedItem item, IDeliverable delivery)
        {
            pricedItems.Add(item);
            deliverables.Add(delivery);
        }

        public decimal CalculateTotalCost()
        {
            decimal total = 0;

            foreach (var item in pricedItems)
                total += item.GetPrice();

            foreach (var delivery in deliverables)
                total += delivery.GetDeliveryCost();

            return total;
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

    public enum ItemCategory
    {
        Electronics,
        Food
    }

    public abstract class ItemBase
    {
        public string ItemName { get; set; }
        public Dimensions Size { get; set; }
        protected decimal WholesalePrice { get; set; }

        private protected decimal InternalCost { get; set; }
        public ItemCategory Category { get; protected set; }

        protected ItemBase(string name, decimal price, decimal cost)
        {
            ItemName = name;
            WholesalePrice = price;
            InternalCost = cost;
        }
        public abstract void ShowPrices();
    }

    public sealed class ElectronicsItem : ItemBase, IPricedItem, IDeliverable
    {
        public int WarrantyMonths { get; set; }

        public ElectronicsItem(string name, Dimensions size)
            : base(name, 1200, 900)
        {
            WarrantyMonths = 24;
            Size = size;
            Category = ItemCategory.Electronics;
        }

        public override void ShowPrices()
        {
            Console.WriteLine($"Electronics: {ItemName}, Size: {Size}");
            Console.WriteLine($"Price: {WholesalePrice}");
            Console.WriteLine($"Warranty: {WarrantyMonths} months");
            Console.WriteLine($"Category: {Category}");
        }
        public decimal GetPrice() => WholesalePrice;
        public decimal GetDeliveryCost() => 150;
    }
    public sealed class FoodItem : ItemBase, IPricedItem, IDeliverable
    {
        public DateTime? ExpirationDate { get; set; }

        public FoodItem(string name)
            : base(name, 50, 30)
        {
            ExpirationDate = DateTime.Now.AddDays(7);
            Category = ItemCategory.Food;
        }

        public override void ShowPrices()
        {
            Console.WriteLine($"Food: {ItemName}");
            Console.WriteLine($"Price: {WholesalePrice}");
            Console.WriteLine(ExpirationDate.HasValue ? $"Expires: {ExpirationDate.Value:d}" : "Expiration date not specified");
            Console.WriteLine($"Category: {Category}");
        }
        public decimal GetPrice() => WholesalePrice;
        public decimal GetDeliveryCost() => 50;
    }
}
