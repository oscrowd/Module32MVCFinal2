using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module32MVCFinal2;
using Module32MVCFinal2.Middlewares;
using Module32MVCFinal2.Models.Db.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

class Program
{

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);
        builder.Services.AddSingleton<IBlogRepository, BlogRepository>();
        builder.Services.AddSingleton<IRequestRepository, RequestRepository>();

        // Add services to the container.
        builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
        var app = builder.Build();

       

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();
        app.UseRouting();

        app.UseMiddleware<LoggingMiddleware>();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}