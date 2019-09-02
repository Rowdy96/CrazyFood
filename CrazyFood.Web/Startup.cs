using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrazyFood.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot/app";
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<CrazyFoodContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CrazyFoodContext")));
            services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<CrazyFoodContext>();
            services.AddCors();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            //app.Use(async (context, next) =>
            //{
            //    await next();
            //    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
            //    {

            //        context.Request.Path = "/App/index.html";
            //       // UseProxyToSpaDevelopmentServer("http://localhost:4200");
            //        await next();
            //    }
            //});
            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseDefaultFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            //app.Map(new PathString("/api"), x => x.UseMvc());
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",
                template: "{controller}/{action}",
                defaults: new { controller = "Account", action = "Login" });
                
            });
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "App";
            //    spa.UseAngularCliServer(npmScript: "start");
            //});

        }
    }
}
