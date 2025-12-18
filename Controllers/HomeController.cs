using Microsoft.AspNetCore.Mvc;
using Sinif_taski.Models;
using Sinif_taski.ViewModels;

namespace Sinif_taski.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            List<Arrials> products = new List<Arrials>
            {
                new Arrials { Marka = "Apple", Model = "iPhone 13", Price = 999.99, OldPrice = 1099.99, Discount = "10%", Image = "product-1.jpg" },
                new Arrials { Marka = "Samsung", Model = "Galaxy S21", Price = 799.99, OldPrice = 899.99, Discount = "11%", Image = "product-1.jpg" },
                new Arrials { Marka = "Google", Model = "Pixel 6", Price = 699.99, OldPrice = 799.99, Discount = "12%", Image = "product-1.jpg" },
                new Arrials { Marka = "OnePlus", Model = "9 Pro", Price = 969.99, OldPrice = 1069.99, Discount = "9%", Image = "product-1.jpg" },
                new Arrials { Marka = "Sony", Model = "Xperia 1 III", Price = 1199.99, OldPrice = 1299.99, Discount = "8%", Image = "product-1.jpg" },
                new Arrials { Marka = "Huawei", Model = "P50 Pro", Price = 899.99, OldPrice = 999.99, Discount = "10%", Image = "product-1.jpg" },
                new Arrials { Marka = "Xiaomi", Model = "Mi 11", Price = 749.99, OldPrice = 849.99, Discount = "11%", Image = "product-1.jpg" },
                new Arrials { Marka = "Oppo", Model = "Find X3 Pro", Price = 1099.99, OldPrice = 1199.99, Discount = "8%", Image = "product-1.jpg" },
                new Arrials { Marka = "Motorola", Model = "Edge 20", Price = 699.99, OldPrice = 799.99, Discount = "12%", Image = "product-1.jpg" },
                new Arrials { Marka = "Nokia", Model = "8.3 5G", Price = 649.99, OldPrice = 749.99, Discount = "13%", Image = "product-1.jpg" },
                new Arrials { Marka = "Asus", Model = "ROG Phone 5", Price = 999.99, OldPrice = 1099.99, Discount = "10%", Image = "product-1.jpg" },


            };
            List<Product> product = new List<Product>
            {
                new Product { Marka = "Apple", Model = "iPhone 13", Price = 999.99, OldPrice = 1099.99, Discount = "10%", Image = "product-1.jpg" },
                new Product { Marka = "Samsung", Model = "Galaxy S21", Price = 799.99, OldPrice = 899.99, Discount = "11%", Image = "product-1.jpg" },
                new Product { Marka = "Google", Model = "Pixel 6", Price = 699.99, OldPrice = 799.99, Discount = "12%", Image = "product-1.jpg" },
                new Product { Marka = "OnePlus", Model = "9 Pro", Price = 969.99, OldPrice = 1069.99, Discount = "9%", Image = "product-1.jpg" },
                new Product { Marka = "Sony", Model = "Xperia 1 III", Price = 1199.99, OldPrice = 1299.99, Discount = "8%", Image = "product-1.jpg" },
                new Product { Marka = "Huawei", Model = "P50 Pro", Price = 899.99, OldPrice = 999.99, Discount = "10%", Image = "product-1.jpg" },
                new Product { Marka = "Xiaomi", Model = "Mi 11", Price = 749.99, OldPrice = 849.99, Discount = "11%", Image = "product-1.jpg" },
                new Product { Marka = "Oppo", Model = "Find X3 Pro", Price = 1099.99, OldPrice = 1199.99, Discount = "8%", Image = "product-1.jpg" },
                new Product { Marka = "Motorola", Model = "Edge 20", Price = 699.99, OldPrice = 799.99, Discount = "12%", Image = "product-1.jpg" },
                new Product { Marka = "Nokia", Model = "8.3 5G", Price = 649.99, OldPrice = 749.99, Discount = "13%", Image = "product-1.jpg" },
                new Product { Marka = "Asus", Model = "ROG Phone 5", Price = 999.99, OldPrice = 1099.99, Discount = "10%", Image = "product-1.jpg" },
                new Product { Marka = "LG", Model = "Wing 5G", Price = 999.99, OldPrice = 1099.99, Discount = "10%", Image = "product-1.jpg" }
            };

            List<FeatureProduct> featureProducts = new List<FeatureProduct>
            {
                new FeatureProduct { Marka = "Apple", Model = "iPhone 13", Price = 999.99, OldPrice = 1099.99, Discount = "10%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "Samsung", Model = "Galaxy S21", Price = 799.99, OldPrice = 899.99, Discount = "11%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "Google", Model = "Pixel 6", Price = 699.99, OldPrice = 799.99, Discount = "12%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "OnePlus", Model = "9 Pro", Price = 969.99, OldPrice = 1069.99, Discount = "9%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "Sony", Model = "Xperia 1 III", Price = 1199.99, OldPrice = 1299.99, Discount = "8%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "Sony", Model = "Xperia 1 III", Price = 1199.99, OldPrice = 1299.99, Discount = "8%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "Sony", Model = "Xperia 1 III", Price = 1199.99, OldPrice = 1299.99, Discount = "8%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "Sony", Model = "Xperia 1 III", Price = 1199.99, OldPrice = 1299.99, Discount = "8%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "Sony", Model = "Xperia 1 III", Price = 1199.99, OldPrice = 1299.99, Discount = "8%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "Apple", Model = "iPhone 13", Price = 999.99, OldPrice = 1099.99, Discount = "10%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "Apple", Model = "iPhone 13", Price = 999.99, OldPrice = 1099.99, Discount = "10%", Image = "product-1.jpg" },
                new FeatureProduct { Marka = "Apple", Model = "iPhone 13", Price = 999.99, OldPrice = 1099.99, Discount = "10%", Image = "product-1.jpgS" },
            };
            HomeVM homeVM = new HomeVM() { Products = products, FeatureProducts=featureProducts };

            return View(homeVM);
        }
    }
}
