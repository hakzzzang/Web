using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using MVC_TYPE.Models;
using System.Diagnostics;

namespace MVC_TYPE.Controllers
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
            //    EmployeeClass Employee = new EmployeeClass
            //    {
            //        EmpId = 100,
            //        EmpName = "홍길동",
            //        Designation = "대리",
            //        Salary = 25000
            //};
            //1. ViewData["data1"] = Employee;
            //2. ViewBag.data1 = Employee;
            //3. TempData["data1"] = Employee;

            var MyEmployees = new List<EmployeeClass>()
            {
                new EmployeeClass {EmpId = 100, EmpName ="홍길동", Designation = "대리", Salary = 25000 },
                new EmployeeClass {EmpId = 200, EmpName ="김학수", Designation = "사원", Salary = 50000 },
                new EmployeeClass {EmpId = 300, EmpName ="빌게이츠", Designation = "사장", Salary = 100000 },
            };

            return View(MyEmployees);
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