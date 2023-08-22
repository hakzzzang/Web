using Microsoft.AspNetCore.Mvc;

namespace WebQuiz01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(DateTime date1, DateTime date2)
        {
            ViewBag.result1 = (date2 - date1).ToString("dd");
            return View();
        }
    }
}
