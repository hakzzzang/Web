using Microsoft.AspNetCore.Mvc;
using MVC_Model_Car.Models;
using System.Diagnostics;

namespace MVC_Model_Car.Controllers
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
            var Car = new List<carClass>()
            {
                new carClass{ID = 1, Name = "포르쉐", Speed = "매우빠름" },
                new carClass{ID = 2, Name = "아반떼", Speed = "보통"},
                new carClass{ID = 3, Name = "모닝", Speed = "느림"}
            };
            ViewData["data1"] = Car;
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