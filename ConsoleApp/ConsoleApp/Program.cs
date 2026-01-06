using UserLibrary;
using OrderLibrary;
using OrderLibrary.Item;

class Program
{
    public static void Main(string[] args)
    {
        Customer customer = new Customer("John Doe", "john.doe@gmail.com", "Reqular", "Private House");
        PrintCustomerInfo(customer);

        TariffItem basicTarif = new TariffItem("Basic Plan", 300, 0, 100, 10, 6);
        TariffItem fastTarif = new TariffItem("Fast Plan", 650, 0.15m, 1000, 20, 12);
        PrintItem(basicTarif);
        PrintItem(fastTarif);

        OrderBase order = new PriorityOrder("Low", 0.05m);
        order.Items.Add(basicTarif);

        decimal total = order.CalculateTotal();
        Console.WriteLine($"------------------------------------------------");
        Console.WriteLine($"Order Total: {total}");

    }
    
    static void PrintCustomerInfo(Customer customer)
    {
        Console.WriteLine($"Customer: {customer.FullName}; Service Plan: {customer.ServicePlan}; Building: {customer.BuildingType}");
    }

    static void PrintItem(ItemBase item)
    {
        Console.WriteLine($"Item: {item.Name}; Price: {item.Price}");
    }
}
