using Microsoft.AspNetCore.Mvc;
using MVC_Model1.Models;
using System.Diagnostics;

namespace MVC_Model1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var st1 = new StudentModel()
            {
                ID = 1,
                Name = "김학수",
                HP = "010-6510-8518",
                Major = "정보통신공학과"
            };
            ViewBag.stdata1 = st1;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}