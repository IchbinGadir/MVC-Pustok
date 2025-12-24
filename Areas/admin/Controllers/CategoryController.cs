using Microsoft.AspNetCore.Mvc;

namespace Sinif_taski.Areas.admin.Controllers
{
    public class CategoryController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
