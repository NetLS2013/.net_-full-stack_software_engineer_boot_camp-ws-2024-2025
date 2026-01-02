
namespace Library2
{
    public enum OrderStatus { 
        Pending,
        Approved,
        Shipped,
        Delivered,
        Cancelled
    }

    public interface ICalculateDelivery
    {
        decimal CalculateDelivery();
    }

    public interface ICalculateTotalPrice
    {
        decimal CalculateTotalPrice();
    }
    public abstract class OrderBase : ICalculateDelivery, ICalculateTotalPrice
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }
        public decimal Discount { get; set; }

        internal string OrderNumber { get; set; }
        public decimal CalculateDelivery()
        {
            return Price * 0.1m;
        }
        public virtual decimal CalculateTotalPrice()
        {
            decimal deliveryCharge = CalculateDelivery();
            decimal discountAmount = (Price * Discount) / 100;
            return Price + deliveryCharge - discountAmount;
        }

        public virtual void ShowOrderDetails()
        {
            Console.WriteLine($"Order Id: {Id}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Discount: {Discount}");
            Console.WriteLine($"OrderNumber: {OrderNumber}");
            Console.WriteLine($"OrderStatus: {Status}");
            Console.WriteLine($"Delivery Charge: {CalculateDelivery()}");
            Console.WriteLine($"Total Price: {CalculateTotalPrice()}");
        }

        public OrderBase()
        {
            Id = 0;
            Price = 110m;
            Discount = 0.1m;
            OrderNumber = "ORD-0001";
            Status = OrderStatus.Pending;
        }
    }

    public sealed class OnlineOrder : OrderBase
    {
        public bool isOnline { get; set; }
        public OnlineOrder() : base()
        {
            isOnline = true;

        }
        public override void ShowOrderDetails()
        {
            Console.WriteLine($"IsOnline: {isOnline}");
            base.ShowOrderDetails();
        }
        public override decimal CalculateTotalPrice()
        {
            decimal baseTotal = base.CalculateTotalPrice();
            if (isOnline)
            {
                baseTotal -= 10m; 
            }
            return baseTotal;
        }
    }
    public abstract partial class ItemBase
    {
        public string ItemName { get; set; }
        protected decimal ItemDiscount { get; set; }
        private int InternalItemCode { get; set; }

        public partial void DisplayItem();
        private ItemSize itemSize;
        public ItemBase(string itemName)
        {
            ItemName = itemName;
            ItemDiscount = 5.0m;
            InternalItemCode = 1001;

            itemSize = new ItemSize()
            {
                Category = "General",
                Height = 10.5m,
                Width = 5.5m
            };
        }

        struct ItemSize
        {
            public string Category;
            public decimal Height;
            public decimal Width;
        }

    }

    public sealed class FoodItem : ItemBase
    {            
        public int FoodId { get; set; }

        public FoodItem() : base("Food Item")
        {
            FoodId = 1;
        }
        public void ShowItemDetails()
        {
            Console.WriteLine($"FoodId: {FoodId}");

            DisplayItem(); 
        }
    }

    public sealed class ElectronicItem : ItemBase
    {
        public int ElectronicId { get; set; }

        public ElectronicItem() : base("Electronic Item")
        {
            ElectronicId = 2;
        }
        public void ShowItemDetails()
        {
            Console.WriteLine($"ElectronicId: {ElectronicId}");

            DisplayItem();
        }
    }

}
