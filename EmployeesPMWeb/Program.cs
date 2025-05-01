using EmployeesData.DBContext;
using EmployeesData.Repositories.Implementations;
using EmployeesData.Repositories.Interfaces;
using EmployeesService.Services.Implementations;
using EmployeesService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesPMWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureDI(builder.Services);

            builder.Services.AddDbContext<EmployeeDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

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

        private static void ConfigureDI(IServiceCollection services)
        { 
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
