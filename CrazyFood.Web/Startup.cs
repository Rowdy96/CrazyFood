using System;
using System.Threading.Tasks;
using AutoMapper;
using CrazyFood.DomainModel.Data;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.AutoMapper;
using CrazyFood.Repository.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);  

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options => {
                        options.SerializerSettings.ContractResolver =  new DefaultContractResolver();
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    });
            
            services.AddDbContext<CrazyFoodContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CrazyFoodContext")));
            services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<CrazyFoodContext>();
            services.AddCors();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
                              ,IHostingEnvironment env
                              ,IServiceProvider serviceProvider)
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
         
            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseDefaultFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",
                template: "{controller}/{action}",
                defaults: new { controller = "Account", action = "Index" });

                routes.MapRoute(name: "Register",
                    template: "{controller}/{action}",
                    defaults: new { controller = "Account", action = "Register" });

                routes.MapSpaFallbackRoute(
                   name: "spa-fallback",
                   defaults: new { controller = "Account", action = "Index" });
            });

            CreateRoles(serviceProvider).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider
                              .GetRequiredService<RoleManager<IdentityRole>>();

            string[] Roles = { "Admin", "Customer", "Restaurant", "DeliveryBoy" };
            IdentityResult roleResult;

            foreach (var roleName in Roles)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                { 
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var admin = await RoleManager.RoleExistsAsync("Admin");
            if (!admin)
            {
                var user = new Users
                {
                    UserName = "Admin@Promact.com",
                    Name = "Admin",
                    Email = "Admin@Promact.com",
                };

                var password = "Admin@123";

                var result = await serviceProvider.GetRequiredService<UserManager<Users>>().CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await serviceProvider.GetRequiredService<UserManager<Users>>().AddToRoleAsync(user, "Admin");
                }
                
            }
        }




    }
}
