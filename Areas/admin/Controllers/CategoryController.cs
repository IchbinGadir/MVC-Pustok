using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Sinif_taski.DAL;
using Sinif_taski.Models;

namespace Sinif_taski.Areas.admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        public readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return View(categories);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool result = await _context.Categories.AnyAsync(c => c.Name == category.Name);
            if (result)
            {
                ModelState.AddModelError("Name", "Bu category Name artiq sistemde var");
                return View();
            }
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null)
            {
                return NotFound();
            }


            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Category exists = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (exists is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            bool result = await _context.Categories.AnyAsync(c => c.Name == category.Name);

            if (result)
            {
                ModelState.AddModelError("Name", "Bu category artıq var");
                return View();
            }

            exists.Name = category.Name;
            await _context.SaveChangesAsync(result);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null || id < 1)
            {
                return BadRequest();
            }
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


    }
}
