using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Diagnostics;
using System.Xml.Linq;
using WebMiniProject.Models;

namespace WebMiniProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;

        }



        [HttpPost]
        public async Task<IActionResult> SignUp(User userData)
        {
                // DB에 저장 로직
              await _context.Users.AddAsync(userData);
              await _context.SaveChangesAsync();

              return RedirectToAction("Login", "Home");
        }

        public IActionResult Main()
        {
            //넘어온 세션값이 null이 아닐경우
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            return View();
        }

        public IActionResult Login()
        {
            //넘어온 세션값이 null이 아닐경우
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            //SqlServer에 있는 Id/password와 폼에서 입력한 id/password를 비교합니다.
            var myUser = _context.Users.Where(
                x => (x.UserId == user.UserId && x.UserPassword == user.UserPassword)).FirstOrDefault();

            if (myUser != null)
            {
                //세션을 만드는 코드 입니다.

                //세션의 정보를 [Key, Value] 조합으로 만듭니다. Key는 UserSession이란 단어 Value는 DB에 있는 email 값입니다.
                HttpContext.Session.SetString("UserSession", myUser.UserId);



                return RedirectToAction("Main");
            }
            else
            {
                ViewBag.Message = "로그인 실패";
            }

            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션정보를 삭제합니다.
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login", "Home");  //로그아웃 후 바로 로그인 화면으로 이동
            }
            return View();
        }



        public IActionResult SignUP()
        {
            //넘어온 세션값이 null이 아닐경우
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }

            return View();
        }

        public IActionResult ResumeWrite()
        {
            //넘어온 세션값이 null이 아닐경우
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                string userId = HttpContext.Session.GetString("UserSession").ToString();

                // DB에서 사용자 정보 가져오기
                User user = _context.Users.FirstOrDefault(u => u.UserId == userId);

                if (user != null)
                {
                    // 사용자 정보를 ViewBag에 저장
                    ViewBag.UserId = user.UserId;
                    ViewBag.UserName = user.UserName;
                    ViewBag.UserGender = user.UserGender;
                    ViewBag.UserPhoneNumber = user.UserHp;
                    // 뷰에 모델 전달
                    return View();
                }
            }
            return RedirectToAction("Login");
        }

        // POST: 삽입기능
        [HttpPost]
        public async Task<IActionResult> ResumeWrite(Resume ResumeData, string submitButton)
        {
            if (ModelState.IsValid)
            {
                if (submitButton == "이력서 제출")
                {
                    await _context.Resumes.AddAsync(ResumeData);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ResumeWrite", "Home");
                }
                else if (submitButton == "엑셀로 저장")
                {
                    // 엑셀로 저장 로직
                    using (var existingPackage = new ExcelPackage(new FileInfo("C:\\Users\\LG\\Desktop\\resume.xlsx")))
                    {
                        var worksheet = existingPackage.Workbook.Worksheets[0]; // 원하는 워크시트 선택

                        // 새로운 정보 추가
                        worksheet.Cells["D4"].Value = ResumeData.Name;
                        worksheet.Cells["D6"].Value = ResumeData.Hp;
                        worksheet.Cells["B10"].Value = ResumeData.Education;
                        worksheet.Cells["B16"].Value = ResumeData.Certificate;
                        worksheet.Cells["B22"].Value = ResumeData.Cl;

                        // 엑셀 파일 저장
                        var updatedExcelBytes = existingPackage.GetAsByteArray();

                        // 업데이트된 엑셀 파일 다운로드
                        return File(updatedExcelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "updated_excel_file.xlsx");
                    }
                }
            }
            return View(ResumeData);
        }

        public async Task<IActionResult> Corporation(string searchString)
        {
            //넘어온 세션값이 null이 아닐경우
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            var cop = from m in _context.Corporations
                      select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                cop = cop.Where(s => s.CorporationName.Contains(searchString));
            }
            return View(await cop.ToListAsync());
        }

        public async Task<IActionResult> ApplyStatus()
        {
            //넘어온 세션값이 null이 아닐경우
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
                string userId = HttpContext.Session.GetString("UserSession").ToString();

                // 현재 로그인된 세션 Id와 일치하는 UserId 열의 레코드만 가져오기
                var resumeList = await _context.Resumes.Where(r => r.UserId == userId).ToListAsync();

                return View(resumeList);
            }
            else
            {
                // 세션이 없으면 로그인 페이지로 리디렉션 또는 다른 처리를 수행할 수 있습니다.
                return RedirectToAction("Login");
            }
        }

        public IActionResult Chart()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            var data = _context.Resumes
            .GroupBy(r => r.CorporationName)
          .Select(g => new
          {
              CorporationName = g.Key,
              Count = g.Count()
          })
          .ToList();

            var corporationNames = data.Select(d => d.CorporationName).ToArray();
            var counts = data.Select(d => d.Count).ToArray();

            ViewBag.CorporationNames = corporationNames;
            ViewBag.Counts = counts;
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