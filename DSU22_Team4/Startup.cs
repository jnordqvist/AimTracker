using DSU22_Team4.Data;
using DSU22_Team4.Infrastructure;
using DSU22_Team4.Repositories;
using DSU22_Team4.Repositories.OpenWeather;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU22_Team4
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
            services.AddScoped<IRepository, Repository>();
            services.AddSingleton<IApiClient, ApiClient>();
            services.AddScoped<IDbRepository, DbRepository>();

            string connection = Configuration["ConnectionStrings:Default"];

            try
            {
                string weatherKey = Configuration["ConnectionStrings:Weather"];
                services.AddSingleton<IOpenWeather>(provider => new OpenWeather(provider.GetService<IApiClient>(), weatherKey));
            }
            catch
            {

            }                                                      

            services.AddDbContext<AppDbContext>(o => o.UseNpgsql(connection,
            options => options.SetPostgresVersion(new Version(9, 5))));

            services.AddDbContext<LoginDbContext>(o => o.UseNpgsql(connection,
            options => options.SetPostgresVersion(new Version(9, 5))));

            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<LoginDbContext>(); ;

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }
            );

            services.AddControllersWithViews();
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
