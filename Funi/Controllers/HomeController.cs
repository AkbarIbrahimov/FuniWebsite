using System.Diagnostics;
using Funi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Funi.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

      

       
        public IActionResult Error()
        {
            return View();
        }
    }
}
