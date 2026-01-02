
namespace Library2
{
    public partial class ItemBase
    {
        public partial void DisplayItem()
        {
            Console.WriteLine($"Item Name: {ItemName}");
            Console.WriteLine($"Item Discount: {ItemDiscount}");
            Console.WriteLine($"Category: {itemSize.Category}");
            Console.WriteLine($"InternalItemCode: {InternalItemCode}");
            Console.WriteLine($"Height: {itemSize.Height}");
            Console.WriteLine($"Width: {itemSize.Width}");


        }
    }
}
