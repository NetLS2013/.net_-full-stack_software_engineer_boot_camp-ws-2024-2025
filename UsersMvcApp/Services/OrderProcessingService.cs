using UsersMvcApp.Models;

namespace UsersMvcApp.Services
{
    public class BaseCalculationService
    {
        public virtual void ProcessCosts(OrderViewModel model)
        {
            model.TotalItemsPrice = model.Items.Sum(i => i.GetPrice());
            model.TotalDeliveryCost = model.Items.Sum(i => i.GetDeliveryCost());
            model.DiscountPercent = 0; // Базова знижка
        }
    }

    public class OrderProcessingService : BaseCalculationService
    {
        public override void ProcessCosts(OrderViewModel model)
        {
            base.ProcessCosts(model); // Спочатку рахуємо базові суми

            // якщо в замовленні є електроніка — знижка 10%
            if (model.Items.Any(i => i is ElectronicsItem))
            {
                model.DiscountPercent = 10;
            }
        }
    }
}