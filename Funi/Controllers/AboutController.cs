using Microsoft.AspNetCore.Mvc;

namespace Funi.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonDetail()
        {
            return View();
        }
    }
}
