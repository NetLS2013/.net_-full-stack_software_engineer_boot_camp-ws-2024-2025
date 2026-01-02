using System;
using UsersLibrary;
using OrdersLibrary;

class Program
{
    static void Main()
    {
        Customer customer = new Customer(101, "Іван", "ivan@mail.com");
        customer.ShowPrivateData();

        Order order = new Order(555);
        order.ShowDiscounts();

        Item item = new Item("Ноутбук");
        item.ShowPrices();
    }
}

