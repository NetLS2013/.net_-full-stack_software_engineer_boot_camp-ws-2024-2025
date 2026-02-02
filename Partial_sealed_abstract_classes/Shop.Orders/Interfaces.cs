using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public interface IOrderTotalCalculator
    {
        decimal CalculateTotal(decimal sum);
    }
    public interface IOrderPriceCalculator
    {
        decimal CalculatePrice();
    }

    public interface IShippingCalculator
    {
        decimal CalculateDeliveryCost();
    }
    public interface IDeliveryOrder
    {
        bool DeliverOrder();
    }
}
