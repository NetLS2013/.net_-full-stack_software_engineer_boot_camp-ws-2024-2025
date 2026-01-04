using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public interface IOrderTotalCalculator
    {
        decimal CalculateTotal();
    }

    public interface IShippingCalculator
    {
        decimal CalculateDeliveryCost();
    }
}
