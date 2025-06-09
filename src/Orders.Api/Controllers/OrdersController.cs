using Microsoft.AspNetCore.Mvc;
using Orders.Application.Interfaces;
using Orders.Domain.Models;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;
        [HttpGet]
        public IActionResult Index() => Ok("Welcome to Orders Api.");

        [HttpPost]
        [ActionName("Orders")]
        public IActionResult CreateOrder([FromBody] Order orderRequest)
        {
            _orderService.CreateOrderAsync(orderRequest);
            return Ok();
        }
    }
}
