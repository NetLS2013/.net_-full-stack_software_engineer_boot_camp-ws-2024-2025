using OrderLibrary;

namespace ConsoleApp.Repository
{
    public interface IOrderRepository
    {
        void Save(OrderBase order);

    }
}
