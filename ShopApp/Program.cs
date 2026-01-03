using PerformanceTests;
using System;
using UsersLibrary;
using OrdersLibrary;

class Program
{
    static void Main()
    {
        Address ivanAddress = new Address(City.Kyiv, "Хрещатик", "10");

        User user = new Customer(101, "Iван", "ivan@mail.com", ivanAddress);
        user.ShowInfo();

        Console.WriteLine();

        Address olenaAddress = new Address(City.Lviv, "Франка", "12");

        PremiumUser premium = new PremiumUser(2, "Олена", "olena@mail.com", olenaAddress);
        premium.AddBonus(50);
        premium.ShowInfo();

        Console.WriteLine();

        Dimensions laptopSize = new Dimensions(35.5, 24.2, 2.0); // розміри

        ElectronicsItem laptop = new ElectronicsItem("Ноутбук", laptopSize); // товари
        FoodItem apple = new FoodItem("Яблуко");

        laptop.ShowPrices(); // показ цін
        Console.WriteLine();
        apple.ShowPrices();
        Console.WriteLine();

        IPricedItem pricedLaptop = laptop; // застосовуємо інтерфейси
        IDeliverable deliveryLaptop = laptop;

        IPricedItem pricedApple = apple;
        IDeliverable deliveryApple = apple;

        Order order = new Order(555);
        order.AddItem(pricedLaptop, deliveryLaptop);
        order.AddItem(pricedApple, deliveryApple);

        Console.WriteLine();

        decimal total = order.CalculateTotalCost();
        Console.WriteLine($"Delivery laptop: {deliveryLaptop.GetDeliveryCost()} грн");
        Console.WriteLine($"Delivery apple: {deliveryApple.GetDeliveryCost()} грн");
        Console.WriteLine($"Total order cost: {total} грн");
        order.ShowDiscounts();

        Console.WriteLine();
        StringPerformanceTest.Run();
    }
}
