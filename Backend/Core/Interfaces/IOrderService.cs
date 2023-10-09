using Core.Entites;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        IQueryable<Order> GetOrders();
    }
}