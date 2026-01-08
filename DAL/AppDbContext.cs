using Microsoft.EntityFrameworkCore;
using Sinif_taski.Models;

namespace Sinif_taski.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

       
        public DbSet<FeatureProduct> FeatureProducts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

