using Orders.Application.Interfaces;
using Orders.Domain.Models;

namespace Orders.Application.Services
{
    public class OrderService(IOrderValidationService validationService,
        IOrderRepository orderRepo) : IOrderService
    {
        private readonly IOrderValidationService _validationService = validationService;
        private readonly IOrderRepository _orderRepo = orderRepo;
        public async Task CreateOrderAsync(Order order)
        {
            var isOrderValid = await _validationService.ValidateOrderAsync(order);
            if (!isOrderValid)
            {
                throw new ArgumentException("Order is not valid");                
            }
            await _orderRepo.SaveOrderAsync(order);
        }
    }
}
