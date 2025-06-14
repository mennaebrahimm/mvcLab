using lab2.Models;
using lab2.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(option => {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            builder.Services.AddDbContext<Context>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
                });

                 
            builder.Services.AddScoped<ICouseRepository,CourseRepository>();
            var app = builder.Build();

          //  builder.Services.AddSession();
           
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
