namespace OrderLibrary;

public class ExtendedOrder : OrderBase
{
    public void ApplySpecialDiscount(decimal discount)
    {
        DiscountPercentage = discount;
    }

    public override decimal CalculateShippingCost()
    {
        decimal totalVolume = 0;
        foreach (var item in Items)
        {
            totalVolume += (decimal)item.Dimensions.GetVolume();
        }

        return totalVolume > 5000 ? 20.0m : 10.0m;
    }

    public override string GetShippingDetails()
    {
        return $"Standard Ground Shipping (Cost based on volume of {Items.Count} items)";
    }
}