using BeSpokedBikes.Data;
using BeSpokedBikes.Services;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BeSpokedContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BeSpokedBikesDB")));

            builder.Services.AddScoped<ICommissionService, CommissionService>();

            builder.Services.AddScoped<IPricingService, PricingService>();


            var app = builder.Build();

            // Seed the database
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<BeSpokedContext>();
                context.Database.EnsureCreated(); // Creates the database if it does not exist
                DbInitializer.Initialize(context);
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
