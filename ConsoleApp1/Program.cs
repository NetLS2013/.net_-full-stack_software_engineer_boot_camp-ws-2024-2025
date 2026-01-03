using UserLibrary;
using OrderLibrary;

class Program
{
    static void Main(string[] args)
    {
        Customer customer = new Customer();
        customer.FullName = "Vladyslav Shnurok";
        customer.Email = "vlad@test.com";
        
        // customer.RegistrationType = "VIP"; // Помилка компіляції (protected)
        // customer.CreatedAt; // Помилка компіляції (internal, бо ми в іншій збірці)

        Console.WriteLine(customer.GetCustomerDetails());

        ExtendedOrder myOrder = new ExtendedOrder();
        
        ItemBase item = new ItemBase { Name = "MacBook", PublicPrice = 10000 };
        item.SetCost(800);
        
        // item.BaseCost = 500; // Помилка (protected)

        myOrder.Items.Add(item);
        myOrder.ApplySpecialDiscount(0.1m); 

        Console.WriteLine($"Total: {myOrder.CalculateTotal()}");
    }
}

public class ExtendedOrder : OrderBase
{
    public void ApplySpecialDiscount(decimal discount)
    {
        DiscountPercentage = discount;
    }
}