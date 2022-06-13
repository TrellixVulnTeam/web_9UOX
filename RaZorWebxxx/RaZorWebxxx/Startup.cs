using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RaZorWebxxx.Models;
using RaZorWebxxx.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaZorWebxxx
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<MyBlogContext>(options =>
            {
                string conect = Configuration.GetConnectionString("AppMvcconnectstring");
                options.UseSqlServer(conect);

            });




            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton<Plainetservice>();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);

            });
            services.AddSingleton(typeof(ProductServices), typeof(ProductServices));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                   
                    name: "product1",
                    pattern: "{controller}/{action=Index}/{id?}",
                 areaName: "ProductManage"


                    );
                endpoints.MapGet("/sayhi",
                  async (context) =>
                  {
                      await context.Response.WriteAsync("Hello");
                  });
                endpoints.MapControllerRoute(
                     name:"first",pattern:"{url}/{id?}",
                     defaults:new {controller="First",action= "Viewproduct" },
                     constraints: new
                     {
                         url = "xemsanpham"
                     }

                    
                    );

               

                endpoints.MapControllerRoute(
                    name:"firstroute",pattern:"start-here",defaults: new {controller="First",action= "Viewproduct",id=3 }

                    );
                endpoints.MapRazorPages();
            });
        }
    }
}
