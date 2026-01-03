namespace OrderLibrary;

public sealed class ElectronicsItem : ItemBase
{
    public int WarrantyMonths { get; set; }

    public ElectronicsItem(string name, decimal price, int warranty) : base(name, price)
    {
        WarrantyMonths = warranty;
    }
}

public sealed class ClothingItem : ItemBase
{
    public ClothingSize Size { get; set; }
    public FabricType Material { get; set; }

    public ClothingItem(string name, decimal price, ClothingSize size) : base(name, price)
    {
        Size = size;
    }
}