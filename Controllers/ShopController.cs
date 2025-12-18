using Microsoft.AspNetCore.Mvc;

namespace Sinif_taski.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
