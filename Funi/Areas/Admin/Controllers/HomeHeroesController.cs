using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Funi.DAL;
using Funi.Models;

namespace Funi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeHeroesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeHeroesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/HomeHeroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Heroes.ToListAsync());
        }

        // GET: Admin/HomeHeroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HomeHeroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeHero homeHero, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    homeHero.Image = "uploads/" + uniqueFileName;
                }

                _context.Add(homeHero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeHero);
        }

        // GET: Admin/HomeHeroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var homeHero = await _context.Heroes.FindAsync(id);
            if (homeHero == null) return NotFound();

            return View(homeHero);
        }

        // POST: Admin/HomeHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HomeHero homeHero, IFormFile? imageFile)
        {
            if (id != homeHero.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var dbHero = await _context.Heroes.FindAsync(id);
                if (dbHero == null) return NotFound();

                // məlumatları update edirik
                dbHero.Title = homeHero.Title;
                dbHero.Description = homeHero.Description;

                if (imageFile != null && imageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // yeni şəkli yazırıq
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // köhnə şəkil varsa silirik
                    if (!string.IsNullOrEmpty(dbHero.Image))
                    {
                        string oldFileName = Path.GetFileName(dbHero.Image); // yalnız fayl adı
                        string oldPath = Path.Combine(uploadsFolder, oldFileName);

                        if (System.IO.File.Exists(oldPath))
                            System.IO.File.Delete(oldPath);
                    }

                    dbHero.Image = "uploads/" + uniqueFileName; // yenisini set edirik
                }

                _context.Update(dbHero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(homeHero);
        }

        // GET: Admin/HomeHeroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var homeHero = await _context.Heroes.FirstOrDefaultAsync(m => m.Id == id);
            if (homeHero == null) return NotFound();

            return View(homeHero);
        }

        // POST: Admin/HomeHeroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeHero = await _context.Heroes.FindAsync(id);
            if (homeHero != null)
            {
                if (!string.IsNullOrEmpty(homeHero.Image))
                {
                    string oldPath = Path.Combine(_env.WebRootPath, homeHero.Image.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                _context.Heroes.Remove(homeHero);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool HomeHeroExists(int id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }
    }
}
