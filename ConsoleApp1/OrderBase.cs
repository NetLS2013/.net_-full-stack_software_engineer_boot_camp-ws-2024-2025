namespace OrderLibrary;

public class OrderBase
{
    public Guid OrderId { get; set; } = Guid.NewGuid();
    public List<ItemBase> Items { get; set; } = new();
    
    protected decimal DiscountPercentage { get; set; }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            total += item.PublicPrice;
        }
        return total * (1 - DiscountPercentage);
    }
}