using Microsoft.AspNetCore.Mvc;

namespace SumOfNum.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class NumberController : ControllerBase
        {
            [HttpGet("add")]
            public IActionResult GetSum()
            {
                int sum= 0;
                for(int i = 1; i <= 100; i++)
                { 
                    sum++;
                }

                return Ok(sum);

            }
        }
    }

