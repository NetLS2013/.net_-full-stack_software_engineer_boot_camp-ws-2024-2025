using ConsoleApp.Repository;
using OrderLibrary;
using OrderLibrary.Item;
using UserLibrary;

namespace ConsoleApp.Service
{
    public class LoggingOrderService : OrderService
    {
        public LoggingOrderService(IOrderRepository repository) : base(repository)
        {
        }

        public override OrderBase CreateOrder(ItemBase[] items, decimal discount, PriorityLevel priority, Customer customer)
        {
            Console.WriteLine($"[LOG]: Starting order creation for {customer.Email} with {items.Length} items...");

            OrderBase order = base.CreateOrder(items, discount, priority, customer);

            Console.WriteLine($"[LOG]: Order {order.Id} created successfully. Total: {order.CalculateTotalPrice()}");

            return order;
        }

    }
}
