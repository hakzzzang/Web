using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_Diary.Models;

namespace WebApp_Diary.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiaryContextDB context;
        public HomeController(DiaryContextDB context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }



        // POST: 삽입기능
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("No,Date,Contents,Writer")] Diary Diarys)
        {
            if (ModelState.IsValid)
            {
                context.Add(Diarys);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Diarys);
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