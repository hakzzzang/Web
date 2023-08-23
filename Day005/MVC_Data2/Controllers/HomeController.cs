using Microsoft.AspNetCore.Mvc;
using MVCData.Models;
using System.Diagnostics;

namespace MVCData.Controllers
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
            return View();
        }
        public IActionResult UseViewBag()
        {
            ViewBag.data1 = "홍길동";
            ViewBag.data2 = 100;
            ViewBag.data3 = DateTime.Now.ToString("yyyy-mm-dd");

            string[] arr = { "사과", "딸기", "배" };
            ViewBag.data4 = arr;

            ViewBag.data5 = new List<string>
            {
                "족구","야구","농구"
            };

            return View();
        }

        public IActionResult UseTempData()
        {
            ViewData["data1"] = "홍길동";
            ViewBag.data2 = "이순신";
            TempData["data3"] = "강감찬";
            TempData["data4"] = new List<string>()
            {
                "야구", "축구", "농구"
            };
            TempData.Keep("data3");
            return View();
        }

        public IActionResult About()
        {
            TempData.Keep("data3");
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