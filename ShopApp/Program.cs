using System;
using UsersLibrary;
using OrdersLibrary;

class Program
{
    static void Main()
    {
        User user = new Customer(101, "Iван", "ivan@mail.com");
        user.ShowInfo();

        Console.WriteLine();

        PremiumUser premium = new PremiumUser(2, "Олена", "olena@mail.com");
        premium.AddBonus(50);
        premium.ShowInfo();

        Console.WriteLine();

        Order order = new Order(555);
        order.ShowDiscounts();

        Console.WriteLine();

        ItemBase laptop = new ElectronicsItem("Ноутбук");
        laptop.ShowPrices();

        Console.WriteLine();

        ItemBase apple = new FoodItem("Яблуко");
        apple.ShowPrices();
    }
}
