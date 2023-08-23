using exchangeRate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace exchangeRate.Controllers
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
        [HttpPost]
        public IActionResult Index(int money)
        {
            double usd = money*0.00075;
            double eur = money*0.00069;
            double jpy = money*0.11;
            double cny = money*0.0054;
            ViewBag.Result1 = Math.Round(usd, 2);
            ViewBag.Result2 = Math.Round(eur, 2);
            ViewBag.Result3 = Math.Round(jpy, 2);
            ViewBag.Result4 = Math.Round(cny, 2);
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