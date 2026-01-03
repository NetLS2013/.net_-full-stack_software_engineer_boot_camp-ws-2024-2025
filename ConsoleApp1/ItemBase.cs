namespace OrderLibrary;

public abstract class ItemBase
{
    public string Name { get; set; }
    public decimal PublicPrice { get; set; }
    protected decimal BaseCost { get; set; }

    protected ItemBase(string name, decimal price)
    {
        Name = name;
        PublicPrice = price;
    }

    public void SetCost(decimal cost)
    {
        BaseCost = cost;
    }
}