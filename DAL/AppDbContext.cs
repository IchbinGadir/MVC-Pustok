using Microsoft.EntityFrameworkCore;
using Sinif_taski.Models;

namespace Sinif_taski.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> optionsBuilder) : base(optionsBuilder)
    {
    }

    public DbSet<FeatureProduct> FeatureProducts { get; set; }
}
