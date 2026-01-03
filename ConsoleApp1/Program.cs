using UserLibrary;
using OrderLibrary;

class Program
{
    static void Main(string[] args)
    {
        Customer regularUser = new Customer { FullName = "Vladyslav Shnurok", Email = "vlad@test.com" };
        Console.WriteLine(regularUser.GetWelcomeMessage());
        Console.WriteLine(regularUser.GetCustomerDetails());
        Console.WriteLine();

        PremiumCustomer vipUser = new PremiumCustomer { FullName = "Elon Musk" };
        Console.WriteLine(vipUser.GetWelcomeMessage());
        Console.WriteLine();

        ExtendedOrder myOrder = new ExtendedOrder();
        
        var phone = new ElectronicsItem("iPhone 17 pro max", 1200, 24);
        phone.SetCost(900);

        var tShirt = new ClothingItem("Gucci Shirt", 500, "L");
        tShirt.Material = "Cotton"; 
        tShirt.SetCost(50);

        myOrder.Items.Add(phone);
        myOrder.Items.Add(tShirt);

        Console.WriteLine("--- Order Details ---");
        foreach (var item in myOrder.Items)
        {
            Console.Write($"Item: {item.Name}, Price: ${item.PublicPrice} ");

            if (item is ElectronicsItem electronics)
            {
                Console.WriteLine($"[Electronics] Warranty: {electronics.WarrantyMonths} months");
            }
            else if (item is ClothingItem clothing)
            {
                Console.WriteLine($"[Clothing] Size: {clothing.Size}, Material: {clothing.Material}");
            }
            else
            {
                Console.WriteLine("[Generic Item]");
            }
        }

        myOrder.ApplySpecialDiscount(0.15m); 
        Console.WriteLine("---------------------");
        Console.WriteLine($"Total to pay (with discount): ${myOrder.CalculateTotal()}");
    }
}

