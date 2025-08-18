using Microsoft.AspNetCore.Mvc;

namespace Funi.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
