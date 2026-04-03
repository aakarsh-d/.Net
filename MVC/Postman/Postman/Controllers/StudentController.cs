using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Postman.Model;
namespace Postman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new List<Student> {
            new Student { Id=1,Name="Arun",Marks=80},
            new Student { Id=2,Name="Bala",Marks=60},
            new Student { Id=3,Name="Charan",Marks=90},
        };
            return Ok(students);
       }

        [HttpGet("add")]
        public IActionResult AddThreeNumbers(int num1, int num2, int num3)
        {
            int result = num1 + num2 + num3;

            return Ok(result);
        }
    }
}
