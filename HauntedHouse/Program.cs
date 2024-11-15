

using HauntedHouse.ApplicationServices.Services;
using HauntedHouse.Core.Domain;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;

namespace HauntedHouse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<HuntersServices, HuntersServices>();
            builder.Services.AddScoped<IFileServices, FileServices>();
            builder.Services.AddDbContext<HunterContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
