using Microsoft.AspNetCore.Mvc;
using Microsoft.DiaSymReader;
using Microsoft.EntityFrameworkCore;
using MVCPustokApp.Utilities.Extensions;
using Sinif_taski.Areas.admin.ViewModels.Product;
using Sinif_taski.DAL;
using Sinif_taski.Models;
using Sinif_taski.Utilities.Enums;


namespace Sinif_taski.Areas.admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        public readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createProductVM);
            }

            if (createProductVM.Photo == null)
            {
                ModelState.AddModelError("Photo", "Şəkil seçilməlidir");
                return View(createProductVM);
            }

            if (!createProductVM.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Yalnız şəkil faylı");
                return View(createProductVM);
            }

            if (createProductVM.Photo.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Photo", "Max 2MB");
                return View(createProductVM);
            }

            string fileName = Guid.NewGuid() + "_" + createProductVM.Photo.FileName;

            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/assets/image/products",
                fileName
            );

            using (FileStream stream = new(path, FileMode.Create))
            {
                await createProductVM.Photo.CopyToAsync(stream);
            }


            Product product = new Product()
            {
                Title = createProductVM.Title,
                Discount = createProductVM.Discount,
                Order = createProductVM.Order,
                Image = fileName,
                Marka = createProductVM.Marka,
                Model = createProductVM.Model
            };


            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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

            UpdateProductVM updateProductVM = new UpdateProductVM()
            {
                Title = product.Title,
                Discount = product.Discount,
                Order = product.Order,
                Marka = product.Marka,
                Model = product.Model,
                Image = product.Image
            };
            return View(updateProductVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateProductVM updateProductVM) 
        {
            if (!ModelState.IsValid) 
            {
                return View (updateProductVM);
            }
            Product product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);

            if (updateProductVM.Photo is not null) 
            {
                if (!updateProductVM.Photo.ValidateType("image/")) 
                {
                    ModelState.AddModelError(nameof(updateProductVM.Photo),"invalide type");
                    return View(updateProductVM);
                }
                if (updateProductVM.Photo.ValidateSize(FileSize.MB,20))
                {
                    ModelState.AddModelError(nameof(updateProductVM.Photo), "invalide size");
                    return View(updateProductVM);
                }

                string fileName = await updateProductVM.Photo.CreateFile(_env.WebRootPath,"assets","image","products",updateProductVM.Image);
                product.Image= fileName;
            }
            product.Title = updateProductVM.Title;
            product.Discount = updateProductVM.Discount;
            product.Order = updateProductVM.Order;
            product.Marka = updateProductVM.Marka;
            product.Model = updateProductVM.Model;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
