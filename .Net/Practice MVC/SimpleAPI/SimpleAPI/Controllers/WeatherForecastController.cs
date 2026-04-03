using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "API is working from IIS!";
        }
    }
}