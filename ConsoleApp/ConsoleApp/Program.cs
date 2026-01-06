using UserLibrary;
using OrderLibrary;
using OrderLibrary.Item;

class Program
{
    public static void Main(string[] args)
    {
        PremiumCustomer customer = new PremiumCustomer("John Doe", "john.doe@gmail.com", "Reqular", "Private House");
        customer.DefaultShippingAddress = new Address("Lviv", "Konovaltsia Street", "10B", 2);
        customer.PersonalDiscountRate = 0.05m;
        PrintCustomerInfo(customer);

        TariffItem basicTarif = new TariffItem("Basic Plan", 300, customer.PersonalDiscountRate, 100, 10, 6);
        PrintItem(basicTarif);

        TariffItem fastTarif = new TariffItem("Fast Plan", 650, 0.15m + customer.PersonalDiscountRate, 1000, 20, 12);
        PrintItem(fastTarif);

        ServiceItem installationService = new ServiceItem("Installation Service", 900, customer.PersonalDiscountRate, 3, true);
        PrintItem(installationService);

        HardwareItem router = new HardwareItem(
            "Router v1", 1900, customer.PersonalDiscountRate, "56524545", 1.8m, new ItemSize(20, 15, 5)
            );
        PrintItem(router);

        OrderBase order = new PriorityOrder("Low", 0.05m);
        order.Items.Add(basicTarif);
        order.Items.Add(router);
        order.Items.Add(installationService);

        PrintFinancialInfo(order);
        PrintDeliveryInfo(order, customer.DefaultShippingAddress);

    }
    

    static void PrintCustomerInfo(Customer customer)
    {
        Console.WriteLine($"Customer: {customer.FullName}; Service Plan: {customer.ServicePlan}; Building: {customer.BuildingType}");
    }

    static void PrintItem(ItemBase item)
    {
        Console.WriteLine($"Item: {item.Name}; Price: {item.Price}");
    }

    static void PrintFinancialInfo(IPriceCalculator calc)
    {
        Console.WriteLine($"------------------------------------------------");
        Console.WriteLine($"Raw Price:\t{calc.CalculateRawPrice():N2}");
        Console.WriteLine($"Discount:\t-{calc.CalculateDiscount():N2}");
        Console.WriteLine($"Total Price:\t{calc.CalculateTotalPrice():N2}");
    }

    static void PrintDeliveryInfo(IDeliveryCalculator calc, Address address)
    {
        Console.WriteLine($"------------------------------------------------");
        Console.WriteLine($"Delivery to {address.City}");
        Console.WriteLine($"Shipping Cost:\t{calc.CalculateDeliveryCost(address.City):N2}");
    }
}
