using Microsoft.AspNetCore.Mvc;

namespace Sinif_taski.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
