using UserLibrary;
using OrderLibrary;
using OrderLibrary.Item;
using ConsoleApp.Service;
using ConsoleApp.Repository;


class Program
{

    private static decimal shopDiscount = 0.05m;

    private static IItemService itemService = new ItemService(new MemoryItemRepository());
    private static ICustomerService customerService = new CustomerService(new MemoryCustomerRepository());
    //private static IOrderService orderService = new OrderService(new MemoryOrderRepository());
    private static IOrderService orderService = new LoggingOrderService(new MemoryOrderRepository());


    public static void Main(string[] args)
    {
        customerService.CreateCustomer(
            "Jake Doe", "jake.doe@gmail.com", ServicePlan.Business, BuildingType.OfficeCenter, 
            new Address("Lviv", "Konovaltsia Street", "25B", 4)
        );


        Customer customer = customerService.GetCustomer("jake.doe@gmail.com");
        PrintCustomerInfo(customer);

        List<ItemBase> items = itemService.GetAllItems();
        items.ForEach(PrintItemInfo);


        OrderBase order = orderService.CreateOrder([items[0], items[1], items[2]], shopDiscount, PriorityLevel.Low, customer);
        PrintFinancialInfo(order);
        PrintDeliveryInfo(order, customer.DefaultShippingAddress);

    }
    

    static void PrintCustomerInfo(Customer customer)
    {
        Console.WriteLine($"Customer: {customer.FullName}; Service Plan: {customer.ServicePlan}; Building: {customer.BuildingType}");
    }

    static void PrintItemInfo(ItemBase item)
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
