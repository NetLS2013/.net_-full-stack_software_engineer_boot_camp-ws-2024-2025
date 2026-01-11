using ConsoleApp.Repository;
using OrderLibrary.Item;

namespace ConsoleApp.Service
{
    public class ItemService : IItemService
    {

        private IItemRepository _repository;


        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public List<ItemBase> GetAllItems()
        {
            return _repository.GetAll();
        }
    }

}