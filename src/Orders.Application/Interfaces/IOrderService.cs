using Orders.Domain.Models;

namespace Orders.Application.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
    }
}
