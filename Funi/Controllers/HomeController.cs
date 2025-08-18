using System.Diagnostics;
using System.Threading.Tasks;
using Funi.DAL;
using Funi.Models;
using Funi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Funi.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        { 
            HomeVM homeVM = new HomeVM
            {
                homeHero=await _db.Heroes.FirstOrDefaultAsync(),
                category=await _db.Categories.ToListAsync(),
            };
            return View(homeVM);
        }

      

       
        public IActionResult Error()
        {
            return View();
        }
    }
}
