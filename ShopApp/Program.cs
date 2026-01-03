using System;
using UsersLibrary;
using OrdersLibrary;

class Program
{
    static void Main()
    {
        Address ivanAddress = new Address("Київ", "Хрещатик", "10");

        User user = new Customer(101, "Iван", "ivan@mail.com", ivanAddress);
        user.ShowInfo();

        Console.WriteLine();

        Address olenaAddress = new Address("Львiв", "Франка", "12");

        PremiumUser premium = new PremiumUser(2, "Олена", "olena@mail.com", olenaAddress);
        premium.AddBonus(50);
        premium.ShowInfo();

        Console.WriteLine();

        Order order = new Order(555);
        order.ShowDiscounts();

        Console.WriteLine();

        Dimensions laptopSize = new Dimensions(35.5, 24.2, 2.0);

        ItemBase laptop = new ElectronicsItem("Ноутбук", laptopSize);
        laptop.ShowPrices();

        Console.WriteLine();

        ItemBase apple = new FoodItem("Яблуко");
        apple.ShowPrices();
    }
}
