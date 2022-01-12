using Microsoft.AspNetCore.Mvc;

namespace DotNet6.Di.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}