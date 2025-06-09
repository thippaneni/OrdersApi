using Orders.Application.Interfaces;
using Orders.Domain.Models;

namespace Orders.Application.Services
{
    public class OrderService : IOrderService
    {
        public Task CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
