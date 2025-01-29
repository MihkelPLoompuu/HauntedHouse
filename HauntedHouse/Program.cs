using HauntedHouse.ApplicationServices.Services;
using HauntedHouse.Core.ServiceInterface;
using HauntedHouse.Data;
using Microsoft.EntityFrameworkCore;

namespace HauntedHouse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IRoomsServices, RoomsServices>();
            builder.Services.AddScoped<IBuildingsServices, BuildingsServices>();
            builder.Services.AddScoped<IHuntersServices, HuntersServices>();
            builder.Services.AddScoped<IFileServices, FileServices>();
            builder.Services.AddDbContext<HauntedHouseContext>(
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
