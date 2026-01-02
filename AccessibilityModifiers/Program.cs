using Library1;
using Library2;

namespace AccessibilityModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ICalculateTotalPrice order = new OnlineOrder();
            //Console.WriteLine($"The total price of online order is {order.CalculateTotalPrice()}");
            //ICalculateDelivery deliveryService = (ICalculateDelivery)order;
            //Console.WriteLine($"Delivery Cost: {deliveryService.CalculateDelivery()}");
            //ItemBase item = new ItemBase();
            //item.ItemName = "Abc";
            //item.DisplayItem(order);
            //User user = new User();
            //user.Id = 1;
            //Console.WriteLine($"User ID: {user.Id}");
            //Customer customer = new Customer();
            //customer.Id = 2;
            //customer.ShowCustomerInfo();
            //Customer2 customer2 = new Customer2();
            //customer2.Id = 3;
            //customer2.ShowCustomer2Info();
            //PremiumUser premiumUser = new PremiumUser();
            //premiumUser.Id = 4;
            //premiumUser.ShowPremiumUserInfo();
            //FoodItem foodItem = new FoodItem();
            //foodItem.ShowItemDetails();
            //ElectronicItem electronicItem = new ElectronicItem();  
            //electronicItem.ShowItemDetails();
            OnlineOrder order = new OnlineOrder();
            order.ShowOrderDetails();
            Console.ReadKey();
        }
    }
}
