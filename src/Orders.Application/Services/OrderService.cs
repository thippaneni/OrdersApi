using Orders.Application.Interfaces;
using Orders.Domain.Models;

namespace Orders.Application.Services
{
    public class OrderService(IEventPublisher eventPublisher) : IOrderService
    {
        private readonly IEventPublisher _eventPublisher = eventPublisher;
        public async Task CreateOrderAsync(Order order)
        {
            await _eventPublisher.PublishAsync(order, "order-placed-topic");
        }
    }
}
