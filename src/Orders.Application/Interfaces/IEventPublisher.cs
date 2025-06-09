using Orders.Domain.Models;

namespace Orders.Application.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync(Order order, string topicName);
    }
}
