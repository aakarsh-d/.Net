using Microsoft.AspNetCore.Mvc;

namespace CartService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        [HttpGet("{userId}")]
        public IActionResult GetCart(int userId)
        {
            var cart = new
            {
                UserId = userId,
                Items = new[]
                {
                    new { ProductId = 1, Quantity = 2 },
                    new { ProductId = 2, Quantity = 1 }
                }
            };

            return Ok(cart);
        }

        [HttpPost("add")]
        public IActionResult AddToCart()
        {
            return Ok("Item added to cart");
        }
    }
}