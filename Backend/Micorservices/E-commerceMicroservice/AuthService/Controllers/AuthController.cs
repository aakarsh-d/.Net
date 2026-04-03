using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
            var token = "dummy-jwt-token";

            return Ok(new
            {
                message = "Login successful",
                token = token
            });
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok("User registered");
        }
    }
}
