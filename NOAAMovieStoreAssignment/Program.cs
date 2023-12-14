using Microsoft.EntityFrameworkCore;
using NOAAMovieStoreAssignment.Data;
using NOAAMovieStoreAssignment.Models;

namespace NOAAMovieStoreAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(
               //options =>
               //{
               //    options.IdleTimeout = TimeSpan.FromMinutes(20);
               //}
               );

       

            var connectionString = builder.Configuration.GetConnectionString(
            "DefaultConnection") ??
            throw new InvalidCastException("Default Connection not found");


            builder.Services.AddDbContext<MovieDbContext>(
               options =>
               options.UseSqlServer(connectionString)

               );
            builder.Services.AddHttpContextAccessor();
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
            }

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