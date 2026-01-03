using System.Collections.Generic;

namespace UsersMvcApp.Models
{
    public class MainPageViewModel
    {
        public List<User> AllUsers { get; set; }        // Список усіх користувачів
        public OrderViewModel SelectedOrder { get; set; } // Деталі замовлення
    }
}
