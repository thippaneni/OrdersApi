using Orders.Application.Interfaces;
using Orders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Repositories
{
    public class OrderRepository(IEventPublisher eventPublisher) : IOrderRepository
    {
        private readonly IEventPublisher _eventPublisher = eventPublisher;
        public async Task SaveOrderAsync(Order order)
        {
            await _eventPublisher.PublishAsync(order, "");
        }
    }
}
