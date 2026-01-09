namespace Sinif_taski.Areas.admin.ViewModels.Product
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Discount { get; set; }
        public int Order { get; set; }
        public string Marka { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public string Model { get; set; }
        public string? Image {  get; set; }
        public IFormFile? Photo { get; set; }
    }
}
