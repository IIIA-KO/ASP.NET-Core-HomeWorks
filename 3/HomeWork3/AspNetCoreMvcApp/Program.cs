using AspNetCoreMvcApp.Services.Implementations;
using AspNetCoreMvcApp.Services.Interfaces;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using CocktailClassLibrary.Printers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCoreMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddControllersWithViews();
            //builder.Services.AddSingleton<ICocktailPrinter, CocktailPrinter>();
            //builder.Services.AddSingleton<ICocktailService, CocktailService>();
            //var app = builder.Build();
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseRouting();
            //app.UseAuthorization();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.Run();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}