using Orders.Domain.Models;

namespace Orders.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task SaveOrderAsync(Order order);
    }
}
