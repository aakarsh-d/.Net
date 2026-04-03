
using Hostelmanagement.DTO;
using Hostelmanagement.Models;
using Hostelmanagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hostelmanagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // CREATE STUDENT + HOSTEL
        //[HttpPost]
        //public IActionResult CreateStudent(Student student, Hostel hostel)
        //{
        //    _service.CreateStudent(student, hostel);
        //    return Ok("Student and Hostel Created");
        //}
        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateStudentDto dto)
        {
            _service.CreateStudent(dto);
            return Ok("Student created");
        }

        // UPDATE ROOM NUMBER
        [HttpPut("update-room")]
        
        public IActionResult UpdateRoom([FromBody] UpdateRoomDto dto)
        {
            _service.UpdateRoom(dto);
            return Ok("Room updated");
        }
        //public IActionResult UpdateRoom(int hostelId, int roomNo)
        //{
        //    _service.UpdateRoom(hostelId, roomNo);
        //    return Ok("Room updated");
        //}

        // DELETE STUDENT
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _service.DeleteStudent(id);
            return Ok("Student Deleted");
        }

        // READ STUDENTS IN HOSTEL
        [HttpGet("hostel-students")]
        public IActionResult GetHostelStudents()
        {
            var data = _service.GetHostelStudents();
            return Ok(data);
        }

        // READ ALL COLLEGE STUDENTS
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var data = _service.GetAllStudents();
            return Ok(data);
        }
    }
}
