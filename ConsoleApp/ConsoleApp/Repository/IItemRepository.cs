using OrderLibrary.Item;

namespace ConsoleApp.Repository
{
    public interface IItemRepository
    {
        List<ItemBase> GetAll();

    }
}