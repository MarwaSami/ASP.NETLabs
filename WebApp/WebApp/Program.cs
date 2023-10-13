
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Models;
using System.Reflection.PortableExecutable;

public class Program
{
    public static void Main()
    {
        WebApplicationBuilder appbuilder = WebApplication.CreateBuilder();
        appbuilder.Services.AddControllersWithViews();
        appbuilder.Services.AddDbContext<MyDBContext>(options =>
        {
            options.UseLazyLoadingProxies().UseSqlServer(
                appbuilder.Configuration.GetConnectionString("Store")
                );
        });
        appbuilder.Services.AddScoped<UnityOfWork>();
        appbuilder.Services.AddScoped<ProductManager>();
        appbuilder.Services.AddScoped<CategoryManager>();
        var appstarter = appbuilder.Build();
        appstarter.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory() + "/Content"),
            RequestPath=""
            
        });
        appstarter.MapDefaultControllerRoute();
        appstarter.Run();

    }

}