using System.Collections.Generic;

namespace UsersMvcApp.Models
{
    public struct Dimensions
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Dimensions(double l, double w, double h) { Length = l; Width = w; Height = h; }
        public override string ToString() => $"{Length}x{Width}x{Height} cm";
    }

    public interface IPricedItem { decimal GetPrice(); }
    public interface IDeliverable { decimal GetDeliveryCost(); }

    public abstract class ItemBase : IPricedItem, IDeliverable
    {
        public string ItemName { get; set; }
        public decimal WholesalePrice { get; set; }
        public abstract decimal GetPrice();
        public abstract decimal GetDeliveryCost();
        public virtual string GetDetails() => ""; // Замість ShowPrices
    }

    public class ElectronicsItem : ItemBase
    {
        public Dimensions Size { get; set; }
        public override decimal GetPrice() => WholesalePrice;
        public override decimal GetDeliveryCost() => 150;
        public override string GetDetails() => $"Габарити: {Size}, Гарантія: 24 міс.";
    }

    public class FoodItem : ItemBase
    {
        public override decimal GetPrice() => WholesalePrice;
        public override decimal GetDeliveryCost() => 50;
        public override string GetDetails() => $"Термін придатності: 7 днів";
    }

    public class OrderViewModel
    {
        public User User { get; set; }
        public int OrderNumber { get; set; }
        public List<ItemBase> Items { get; set; } = new();
        public decimal TotalItemsPrice { get; set; }
        public decimal TotalDeliveryCost { get; set; }
        public decimal DiscountPercent { get; set; } = 10;
        public decimal FinalTotal => (TotalItemsPrice + TotalDeliveryCost) * (1 - DiscountPercent / 100);
    }
}
