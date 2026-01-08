using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sinif_taski.DAL;
using Sinif_taski.Models;

namespace Sinif_taski.Areas.admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        public readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.ToListAsync();

            return View(products);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            if (product.Photo == null)
            {
                ModelState.AddModelError("Photo", "Şəkil seçilməlidir");
                return View(product);
            }

            if (!product.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Yalnız şəkil faylı");
                return View(product);
            }

            if (product.Photo.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Photo", "Max 2MB");
                return View(product);
            }

            string fileName = Guid.NewGuid() + "_" + product.Photo.FileName;

            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/assets/image/products",
                fileName
            );

            using (FileStream stream = new(path, FileMode.Create))
            {
                await product.Photo.CopyToAsync(stream);
            }

            product.Image = fileName;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }

            Product product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int? id, Product product)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }

            Product exists = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (exists == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            bool result = await _context.Products.AnyAsync(c => c.Title == product.Title);
            if (result)
            {
                ModelState.AddModelError("Name", "Bu Product sistemde var");
                return View();
            }

            exists.Title = product.Title;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }

            Product product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
