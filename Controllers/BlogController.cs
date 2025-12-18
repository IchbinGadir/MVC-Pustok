using Microsoft.AspNetCore.Mvc;

namespace Sinif_taski.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
