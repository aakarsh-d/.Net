using Microsoft.AspNetCore.Mvc;
using OneToMany_Dept_.Models;
using OneToMany_Dept_.Service;

namespace OneToMany_Dept_.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _service;

        public DepartmentController(DepartmentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var departments = _service.GetAllDepartments();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _service.AddDepartment(department);
                return RedirectToAction("Index");
            }

            return View(department);
        }
    }
}