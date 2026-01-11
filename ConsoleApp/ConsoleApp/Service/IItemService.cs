using OrderLibrary.Item;

namespace ConsoleApp.Service
{
    public interface IItemService
    {
        List<ItemBase> GetAllItems();

    }
}
