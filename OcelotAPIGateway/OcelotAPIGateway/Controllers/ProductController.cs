using Microsoft.AspNetCore.Mvc;

namespace OcelotAPIGateway.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            return Ok(new[]{
            "Laptop",
            "Smartphone",
            "Tablet"
        });
        }
    }
}
