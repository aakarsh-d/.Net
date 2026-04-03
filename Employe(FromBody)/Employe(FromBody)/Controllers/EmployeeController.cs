using Microsoft.AspNetCore.Mvc;

namespace Employe_FromBody_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        // Static list
        private static List<Employee> employees = new List<Employee>();


        [HttpPost("add")]
        public IActionResult AddEmployees([FromBody] List<Employee> empList)
        {
            employees.AddRange(empList);

            return Ok("Employees added successfully");
        }


        [HttpGet("getall")]
        public IActionResult GetAllEmployees()
        {
            return Ok(employees);
        }


        // 3. Get total salary
        [HttpGet("totalsalary")]
        public IActionResult GetTotalSalary()
        {
            double total = employees.Sum(e => e.Salary);

            return Ok(total);
        }

    }
}