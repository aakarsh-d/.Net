using Microsoft.AspNetCore.Mvc;
using SimpleEFServices.Services;

namespace SimpleEFServices.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorServices _calculator;
        public CalculatorController(CalculatorServices calculator)
        {
            _calculator = calculator;
        }
        public IActionResult Add()
        {
            int result = _calculator.Add(1, 2);
            return Content("Result: " + result);
        }
    }
}
