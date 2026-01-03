using UserLibrary;
using OrderLibrary;

class Program
{
    static void Main(string[] args)
    {
        User regularUser = new Customer { FullName = "Vladyslav Shnurok", Email = "vlad@test.com" };
        User vipUser = new PremiumCustomer { FullName = "Elon Musk" }; // Поліморфізм: змінна типу User

        Console.WriteLine(regularUser.GetWelcomeMessage());
        Console.WriteLine(vipUser.GetWelcomeMessage());
        Console.WriteLine();

        ExtendedOrder myOrder = new ExtendedOrder();
        
        var phone = new ElectronicsItem("iPhone 15", 1200, 24);
        phone.Dimensions = new ItemDimensions(7.1, 14.7, 0.8);

        var tShirt = new ClothingItem("Gucci Shirt", 500, "L");
        tShirt.Material = "Cotton"; 
        tShirt.Dimensions = new ItemDimensions(30, 40, 2);

        myOrder.Items.Add(phone);
        myOrder.Items.Add(tShirt);
        myOrder.ApplySpecialDiscount(0.15m);

        Console.WriteLine("--- Order Processing via Interfaces ---");
        
        PrintOrderFinancials(myOrder);
        PrintShippingLogistics(myOrder);
    }


    static void PrintOrderFinancials(IOrderPricing order)
    {
        Console.WriteLine($"[Finance System]: Total to pay: ${order.CalculateTotal():F2}");
    }

    static void PrintShippingLogistics(IOrderShipping order)
    {
        Console.WriteLine($"[Logistics System]: {order.GetShippingDetails()}");
        Console.WriteLine($"[Logistics System]: Delivery Cost: ${order.CalculateShippingCost():F2}");
    }
}