using Microsoft.AspNetCore.Mvc;
using UsersMvcApp.Models;
using UsersMvcApp.Repositories;
using UsersMvcApp.Services;

namespace UsersMvcApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserRepository _userRepo = new UserRepository();
        private readonly OrderRepository _orderRepo = new OrderRepository();
        private readonly OrderProcessingService _orderService = new OrderProcessingService();

        public IActionResult Index()
        {
            // 1. Отримуємо ВСІХ користувачів з UserRepository
            var allUsers = _userRepo.GetAll();

            // 2. Беремо конкретного користувача зі списку
            var ivan = allUsers.FirstOrDefault(u => u.Name == "Іван");

            // 3. Створюємо замовлення саме ДЛЯ ЦЬОГО користувача
            var order = _orderRepo.CreateOrderForUser(ivan);

            // 4. Обробляємо знижки через сервіс
            _orderService.ProcessCosts(order);

            // 5. Пакуємо все в одну "супер-модель"
            var viewModel = new MainPageViewModel
            {
                AllUsers = allUsers,
                SelectedOrder = order
            };

            return View(viewModel);
        }
    }

}
