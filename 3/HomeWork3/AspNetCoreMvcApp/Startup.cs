﻿using AspNetCoreMvcApp.Services.Implementations;
using AspNetCoreMvcApp.Services.Interfaces;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CocktailClassLibrary.Printers;

namespace AspNetCoreMvcApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutofac();
            services.AddControllersWithViews();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<CocktailPrinter>().As<ICocktailPrinter>();
            builder.RegisterType<CocktailService>().As<ICocktailService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
