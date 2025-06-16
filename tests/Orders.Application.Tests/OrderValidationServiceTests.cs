using Orders.Application.Services;
using Orders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Tests
{
    public class OrderValidationServiceTests
    {
        [Fact]
        public async Task ValidateOrderAsync_ShouldReturnFalse_WhenOrderHasNoItems()
        {
            // Arrange
            var order = new Order { Items = new List<OrderItem>() };
            var validationService = new OrderValidationService();
            
            // Act
            var result = await validationService.ValidateOrderAsync(order);
            
            // Assert
            Assert.False(result);
        }
    }
}
