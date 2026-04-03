using Microsoft.AspNetCore.Mvc;

namespace APIVersionDemo.Controllers
{


    [ApiController]

    [ApiVersion("1.0")]

    [Route("api/v{version:apiVersion}/students")]

    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(new
            {
                Version = "V1",
                Students = new string[] { "Ram", "John", "Sara" }
            });
        }
    }
    [ApiController]

    [ApiVersion("2.0")]

    [Route("api/v{version:apiVersion}/students")]

    public class StudentV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(new
            {
                Version = "V2",
                Students = new[]
                {
                    new { Id = 1, Name = "Ram", Grade = "A"},
                    new { Id = 2, Name = "John", Grade = "B"},
                    new { Id = 3, Name = "Sara", Grade = "A"}
                }
            });
        }
    }
}
