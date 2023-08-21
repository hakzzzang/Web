using Microsoft.AspNetCore.Mvc;

namespace WebAppControler01.Controllers
{
    [Route("/Home")]
    //[Route("[Controller]")]
    public class HomeController : Controller
    {
        [Route("")]
        //[Route("{action}")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("About")]
        //[Route("{action}")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Number/{id?}")]
        //[Route("{action}/{id?}")]
        public int Details(int id)
        {
            return id;
        }
    }
}
