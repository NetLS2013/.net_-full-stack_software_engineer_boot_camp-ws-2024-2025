namespace OrderLibrary;

public abstract class OrderBase
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
}

public class ExtendedOrder : OrderBase
{
    public void ApplySpecialDiscount(decimal discount)
    {
        DiscountPercentage = discount;
    }
}