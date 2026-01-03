namespace OrderLibrary;

public abstract class OrderBase : IOrderPricing, IOrderShipping
{
    public Guid OrderId { get; set; } = Guid.NewGuid();
    public List<ItemBase> Items { get; set; } = new();
    
    protected decimal DiscountPercentage { get; set; }

    public virtual decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            total += item.PublicPrice;
        }
        return total * (1 - DiscountPercentage);
    }

    public abstract decimal CalculateShippingCost();
    
    public virtual string GetShippingDetails()
    {
        return $"Shipping calculated for Order: {OrderId}";
    }
}