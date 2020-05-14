using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestFilm.Forms;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using GestFilm.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GestFilm.Web
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
            services.AddControllersWithViews();

            //A check
            services.AddSession(o => {
                o.IdleTimeout = TimeSpan.FromHours(1);
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

            //A check
            services.AddHttpContextAccessor();
            services.AddTransient<ISessionManager, SessionManager>();

            services.AddSingleton<Uri>(p => new Uri("https://localhost:6001/api/")); // A changer
            services.AddSingleton<IAuthRepository<RegisterForm, LoginForm, User>, AuthRepository>(); // Créer repository dans le model !!!
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
            }
            app.UseStaticFiles();

            app.UseRouting();

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
