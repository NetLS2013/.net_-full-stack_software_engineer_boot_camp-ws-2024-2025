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
        private readonly List<ItemBase> _items = new List<ItemBase>();

        public ReadOnlyCollection<ItemBase> Items
        {
            get { return _items.AsReadOnly(); }
        }

        // знижки “не для юзера”
        protected decimal ManagerDiscountPercent { get; set; }
        protected internal decimal SeasonalDiscountPercent { get; set; }

        public void AddItem(ItemBase item)
        {
            _items.Add(item);
        }

        public abstract decimal CalculateTotal();
    }
}
