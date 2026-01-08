using Microsoft.EntityFrameworkCore;

namespace Sinif_taski
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
           
            builder.Services.AddDbContext<Sinif_taski.DAL.AppDbContext>
            (
                options =>
                {
                    options.UseSqlServer("Server=localhost;Database=APA201PustokamDb;Trusted_Connection=true;Encrypt=false");
                }
            );



            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute
            (
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute
            (
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );


            app.UseStaticFiles();
            


            app.Run();
        }
    }
}
