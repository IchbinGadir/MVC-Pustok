using Microsoft.AspNetCore.Mvc;

namespace Sinif_taski.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
