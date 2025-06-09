using Azure.Messaging.ServiceBus;
using Orders.Application.Interfaces;
using Orders.Domain.Models;
using System.Text.Json;

namespace Orders.Infrastructure.Services
{
    public class AzureServicebusEventPublisher(ServiceBusClient client) : IEventPublisher
    {
        private readonly ServiceBusClient _client = client;
        public async Task PublishAsync(Order order, string topicName)
        {
            var sender = _client.CreateSender(topicName);
            var message = new ServiceBusMessage(JsonSerializer.Serialize(order))
            {
                ContentType = "application/json"
            };

            await sender.SendMessageAsync(message);
        }
    }
}
