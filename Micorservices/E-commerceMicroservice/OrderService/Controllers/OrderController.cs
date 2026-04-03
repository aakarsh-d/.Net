using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = new[]
            {
                new { Id = 1, Product = "Laptop", Quantity = 1 },
                new { Id = 2, Product = "Phone", Quantity = 2 }
            };

            return Ok(orders);
        }
    }
}