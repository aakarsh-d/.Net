using Microsoft.AspNetCore.Mvc;

using practicemvc.Models;
namespace practicemvc.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var items = new Item { Name = "Keyboard" };
            return View(items);
        }
    }
}
