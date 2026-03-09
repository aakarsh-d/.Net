using Microsoft.AspNetCore.Mvc;
using OnetoOneMVC.Models;
using OnetoOneMVC.Services;

namespace OnetoOneMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAllStudents());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student, string roomNumber)
        {
            student.AssignedRoom = new Hostel
            {
                Roomnumber = roomNumber
            };

            _service.AddStudent(student);

            return RedirectToAction("Index");
        }
    }
}
