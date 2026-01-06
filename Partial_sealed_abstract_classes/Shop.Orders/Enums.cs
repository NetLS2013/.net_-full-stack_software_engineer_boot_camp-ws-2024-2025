using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public enum OrderStatus
    {
        Draft = 0,
        Created = 1,
        Paid = 2,
        Shipped = 3,
        Delivered = 4,
        Cancelled = 5
    }

    public enum DeliveryType
    {
        Pickup = 0,
        Courier = 1,
        Post = 2
    }
}
