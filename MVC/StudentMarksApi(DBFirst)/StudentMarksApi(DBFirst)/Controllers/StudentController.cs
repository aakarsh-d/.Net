using Microsoft.AspNetCore.Mvc;
using StudentMarksApi_DBFirst_.Models;

namespace StudentMarksApi_DBFirst_.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class StudentController : ControllerBase
        {
            private readonly DbfirstContext _context;

            public StudentController(DbfirstContext context)
            {
                _context = context;
            }
            [HttpGet]
            public IActionResult GetStudents()
            {
                var students = _context.Students.Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.M1,
                    s.M2,
                    Total = (s.M1 ?? 0) + (s.M2 ?? 0),
                    Grade = CalculateGrade((s.M1 ?? 0) + (s.M2 ?? 0))
                }).ToList();

                return Ok(students);
            }

            private static string CalculateGrade(int total)
            {
                if (total >= 180) return "A";
                if (total >= 150) return "B";
                if (total >= 100) return "C";
                return "Fail";
            }
        }
    
}
