using Microsoft.AspNetCore.Mvc;

namespace WebEmptyQuiz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int number1, int number2)
        {
            ViewBag.result1 = number1 + number2;
            ViewBag.result2 = number1 - number2;
            ViewBag.result3 = number1 * number2;
            ViewBag.result4 = number1 / number2;
            return View();
        }
    }
}
