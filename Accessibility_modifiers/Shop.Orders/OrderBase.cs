using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Orders
{
    public abstract class OrderBase
    {
        public string OrderNumber { get; set; } = Guid.NewGuid().ToString("N");
        public ReadOnlyCollection<ItemBase> Items => _items.AsReadOnly();
        private readonly List<ItemBase> _items = new List<ItemBase>();

        public void AddItem(ItemBase item) => _items.Add(item);

        // protected
        protected decimal ManagerDiscountPercent { get; set; }

        // internal
        internal decimal AccountingDiscountPercent { get; set; }

        // protected internal
        protected internal decimal SeasonalDiscountPercent { get; set; }

        public abstract decimal CalculateTotal();
    }
}
