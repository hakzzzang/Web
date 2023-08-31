using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebAppDiary.Models;

namespace WebAppDiary.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiaryDbContext _context;

        public HomeController(DiaryDbContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.DiaryList.ToListAsync<DiaryClass>();
            return View(students);
        }

        public IActionResult Add()
        {
            return View();
        }

        // POST: 삽입기능
        [HttpPost]
        public async Task<IActionResult> Add(DiaryClass diaryData)
        {
            if (ModelState.IsValid)
            {
                await _context.DiaryList.AddAsync(diaryData);
                await _context.SaveChangesAsync();
                return RedirectToAction("Result", "Home");
            }
            return View(diaryData);
        }

        public IActionResult Result(DiaryClass diaryData)
        {
            return View(diaryData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DiaryList == null)
            {
                return NotFound();
            }

            var diaryData = await _context.DiaryList.FindAsync(id);

            if (diaryData == null)
            {
                return NotFound();
            }
            return View(diaryData);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, DiaryClass diary)
        {
            if (id != diary.No)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //_context.Student.Update(std);
                _context.Update(diary);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(diary);

        }

        public IActionResult Details()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? no)
        {
            if (no == null || _context.DiaryList == null)
            {
                return NotFound();
            }

            var diaryData = await _context.DiaryList.FirstOrDefaultAsync(x => x.No == no);

            if (diaryData == null)
            {
                return NotFound();
            }

            return View(diaryData);
        }

        public async Task<IActionResult> Delete(int? no)
        {
            if (no == null || _context.DiaryList == null)
            {
                return NotFound();
            }
            var diaryData = await _context.DiaryList.FirstOrDefaultAsync((x => x.No == no));

            if (diaryData == null)
            {
                return NotFound();
            }
            return View(diaryData);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? no)
        {
            var diaryData = await _context.DiaryList.FindAsync(no);
            if (diaryData != null)
            {
                _context.DiaryList.Remove(diaryData);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
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