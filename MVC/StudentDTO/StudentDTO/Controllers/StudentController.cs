using Microsoft.AspNetCore.Mvc;
using StudentDTO.DTO;
using StudentDTO.Model;

namespace StudentDTO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();



        [HttpPost("add")]
        public IActionResult CreateStudent(CreateStudent dto)
        {
            Student student=new Student
            {
               Id = dto.Id,
                Name = dto.Name,
                Age = int.Parse(dto.Age)
            };

            students.Add(student);
            return Ok("Student Created");
        }

        [HttpPut]
        public IActionResult UpdateMarks(UpdateStudent dto)
        {
            var student = students.FirstOrDefault(s => s.Id == dto.Id);

            if (student == null)
                return NotFound();

            student.M1 = dto.M1;
            student.M2 = dto.M2;

            student.Total = dto.M1 + dto.M2;

            if (student.Total >= 150)
                student.Grade = "A";
            else if (student.Total >= 100)
                student.Grade = "B";
            else
                student.Grade = "C";

            return Ok("Marks Updated");
        }
        [HttpGet("{id}")]
        public IActionResult GetResultById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            GetResultById result = new GetResultById
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                M1 = student.M1,
                M2 = student.M2,
                Total = student.Total,
                Grade = student.Grade
            };

            return Ok(result);
        }

    }
}
