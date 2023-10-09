
using Core.Entites;

namespace Core.Interfaces
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetCustomersAndOrders();
    }
}