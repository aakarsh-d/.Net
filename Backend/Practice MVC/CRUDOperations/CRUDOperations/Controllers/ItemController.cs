using Microsoft.AspNetCore.Mvc;

namespace CRUDOperations.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
