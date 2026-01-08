
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sinif_taski.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public string? ImageUrl { get; set; }


        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}