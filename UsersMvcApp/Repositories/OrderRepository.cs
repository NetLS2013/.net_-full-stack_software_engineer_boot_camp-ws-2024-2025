using UsersMvcApp.Models;

namespace UsersMvcApp.Repositories
{
    public class OrderRepository
    {
        public OrderViewModel CreateOrderForUser(User user)
        {
            // Створюємо товари
            var laptop = new ElectronicsItem { ItemName = "Ноутбук", WholesalePrice = 1200, Size = new Dimensions(35.5, 24.2, 2.0) };
            var apple = new FoodItem { ItemName = "Яблуко", WholesalePrice = 50 };

            return new OrderViewModel
            {
                User = user, // Беремо вже існуючого користувача
                OrderNumber = 555,
                Items = new List<ItemBase> { laptop, apple }
            };
        }
    }
}
