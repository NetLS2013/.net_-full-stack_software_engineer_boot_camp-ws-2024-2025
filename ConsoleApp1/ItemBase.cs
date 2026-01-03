namespace OrderLibrary;

public class ItemBase
{
    public string Name { get; set; }
    public decimal PublicPrice { get; set; }
    protected decimal BaseCost { get; set; }

    protected decimal CalculateMargin()
    {
        return PublicPrice - BaseCost;
    }

    public void SetCost(decimal cost)
    {
        BaseCost = cost;
    }
}