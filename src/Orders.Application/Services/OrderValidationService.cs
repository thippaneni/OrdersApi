using Orders.Application.Interfaces;
using Orders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Services
{
    public class OrderValidationService : IOrderValidationService
    {
        public Task<bool> ValidateOrderAsync(Order order)
        {
            if (order.Items.Count <=0)
                return Task.FromResult(false);

           var isValidItem = true;
            order.Items.ForEach(item =>
            {
                if (item.Quantity <= 0 || string.IsNullOrEmpty(item.ProductId))
                {                    
                    isValidItem = false;
                    return; // Exit the loop early if an invalid item is found
                }
            });

            return Task.FromResult(isValidItem);
        }
    }
}
