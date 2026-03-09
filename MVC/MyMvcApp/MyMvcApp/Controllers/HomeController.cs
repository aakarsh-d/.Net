using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
using System.Diagnostics;

namespace MyMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Student()
        {
            var s = new { Name = "Ravi", Marks = 90 };
            return Json(s);
        }
        public IActionResult Test()
        {
            return NotFound();
        }
        public IActionResult Square(int? num)      
        {
            if (num == null)
                return Content("Please Provide a number");
            return View(num.Value);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
