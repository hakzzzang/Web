using Microsoft.AspNetCore.Mvc;

namespace WebWeightQuiz.Controllers
{
    public class HomeController : Controller
    {
        double PIBW;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int height, int weight, string sex)
        {
            if (sex == "남성")
            {
                double goodweight = ((height / 10) * 0.1) * ((height / 10) * 0.1) * 22;
                PIBW = (weight / goodweight) * 100;
            }
            else
            {
                double goodweight = ((height/10)*0.1) * ((height/10)*0.1) * 21;
                PIBW = (weight / goodweight) * 100;
            }

            if (PIBW < 90)
            {
                ViewBag.result = "저체중";
            }
            else if (PIBW >= 90 && PIBW < 110)
            {
                ViewBag.result = "정상 체중";
            }
            else if (PIBW >= 110 && PIBW < 120)
            {
                ViewBag.result = "과체중";
            }
            else if (PIBW >= 120 && PIBW < 130)
            {
                ViewBag.result = "경도 비만";
            }
            else if (PIBW >= 130 && PIBW < 160)
            {
                ViewBag.result = "중정도 비만";
            }
            else if (PIBW >= 160)
            {
                ViewBag.result = "정상 체중";
            }
            return View();
        }
    }
}
