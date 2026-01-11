using OrderLibrary;
using OrderLibrary.Item;
using UserLibrary;

internal interface IOrderService
{
    OrderBase CreateOrder(ItemBase[] items, decimal shopDiscount, PriorityLevel priority, Customer customer);

}