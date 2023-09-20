using AnimalAspCoreMvc.Services;
using AnimalsClassLibrary.Printers;
using ShapesClassLibrary.Printers;

namespace AnimalAspCoreMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            // Custom services
            builder.Services.AddSingleton<IAnimalPrinter, AnimalPrinter>();
            builder.Services.AddSingleton<IAnimalService, AnimalService>();
            builder.Services.AddSingleton<IShapePrinter, ShapePrinter>();
            builder.Services.AddSingleton<IShapeService, ShapeService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

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