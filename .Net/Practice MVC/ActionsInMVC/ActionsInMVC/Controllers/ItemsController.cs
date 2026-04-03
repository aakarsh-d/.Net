using ActionsInMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionsInMVC.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview() 
        {
            var item = new Item() { Name = "Keyboard" };
            return View(item);
        }
    public IActionResult Edit(int id)
        {
            return Content("Id : "+ id);
        }
    }
}
