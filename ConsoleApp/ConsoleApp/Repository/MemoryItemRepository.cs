using OrderLibrary.Item;
using UserLibrary;

namespace ConsoleApp.Repository
{
    public class MemoryItemRepository : BaseMemoryRepository<ItemBase>, IItemRepository
    {

        public MemoryItemRepository()
        {
            _data.Add(new TariffItem("Basic Plan", 300, 0, 100, 10, 6));
            _data.Add(new ServiceItem("Installation Service", 900, 0, 3, true));
            _data.Add(new HardwareItem("Cisco Router", 1900, 0, "56524545", 1.8m, new ItemSize(20, 15, 5)));
        }

    }

}