using ConsoleApp.Repository;
using OrderLibrary;
using OrderLibrary.Item;
using UserLibrary;


public class OrderService : IOrderService
{

    private IOrderRepository _repository;


    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public virtual OrderBase CreateOrder(ItemBase[] orderItems, decimal shopDiscount, PriorityLevel priority, Customer customer)
    {
        decimal finalDiscount = customer is PremiumCustomer prem ? prem.PersonalDiscountRate : shopDiscount;

        OrderBase order = new PriorityOrder(priority, finalDiscount);
        order.Items.AddRange(orderItems);

        _repository.Save(order);

        return order;
    }
}