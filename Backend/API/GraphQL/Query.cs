using Core.Entites;
using Core.Interfaces;

namespace API.GraphQL
{
    public class Query
    {
        //injected customerService by dependencyInjection from Program.cs AddScoped
        [UseFiltering]
        public IQueryable<Customer> GetCustomers([Service] ICustomerService customerService)
        {
            return customerService.GetCustomersAndOrders();
        }

        //injected orderService by dependencyInjection from Program.cs AddScoped
        [UseFiltering]
        public IQueryable<Order> GetOrders([Service] IOrderService orderService)
        {
            return orderService.GetOrders();
        }
    }
}