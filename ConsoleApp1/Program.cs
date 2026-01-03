using UserLibrary;
using OrderLibrary;

class Program
{
    static void Main(string[] args)
    {
        Customer regularUser = new Customer { FullName = "Vladyslav Shnurok", Email = "vlad@test.com" };
        Console.WriteLine(regularUser.GetWelcomeMessage());

        PremiumCustomer vipUser = new PremiumCustomer { FullName = "Elon Musk" };
        Console.WriteLine(vipUser.GetWelcomeMessage());
        Console.WriteLine();

        ExtendedOrder myOrder = new ExtendedOrder();
        
        var phone = new ElectronicsItem("iPhone 15", 1200, 24);
        phone.SetCost(900);
        
        phone.Dimensions = new ItemDimensions(7.1, 14.7, 0.8);

        var tShirt = new ClothingItem("Gucci Shirt", 500, "L");
        tShirt.Material = "Cotton"; 
        tShirt.SetCost(50);
        
        tShirt.Dimensions = new ItemDimensions(30, 40, 2);

        myOrder.Items.Add(phone);
        myOrder.Items.Add(tShirt);

        Console.WriteLine("--- Order Details ---");
        foreach (var item in myOrder.Items)
        {
            Console.Write($"Item: {item.Name}, Price: ${item.PublicPrice} ");
            
            Console.Write($"[Box: {item.Dimensions}, Volume: {item.Dimensions.GetVolume():F1} cm3] ");

            if (item is ElectronicsItem electronics)
            {
                Console.WriteLine($"\n   -> Warranty: {electronics.WarrantyMonths} months");
            }
            else if (item is ClothingItem clothing)
            {
                Console.WriteLine($"\n   -> Size: {clothing.Size}, Material: {clothing.Material}");
            }
            else
            {
                Console.WriteLine();
            }
        }

        myOrder.ApplySpecialDiscount(0.15m);
        Console.WriteLine("---------------------");
        Console.WriteLine($"Total to pay (with discount): ${myOrder.CalculateTotal()}");
    }
}

