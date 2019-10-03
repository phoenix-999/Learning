using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ConfiguringApps.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ConfiguringApps
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc().AddMvcOptions(options =>
                {
                    options.RespectBrowserAcceptHeader = true;
                });
        }

        //Метод перенесен в конфигурационный класс StartupDevelopment
        //public void ConfigureDevelopmentServices(IServiceCollection services)
        //{
        //    services.AddSingleton<UptimeService>();
        //    services.AddMvc();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseMiddleware<ErrorMiddleware>();
            if ((Configuration.GetSection("ShortCircuitMiddleware")?.GetValue<bool>("EnableBrowserShortCircuit")).Value)
            {
                app.UseMiddleware<BrowserTypeMiddleware>();
                app.UseMiddleware<ShortCircuitMiddleware>();
            }
            //app.UseMiddleware<ContentMiddleware>();

            app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //Метод перенесен в конфигурационный класс StartupDevelopment
        //public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    app.UseDeveloperExceptionPage();
        //    app.UseStatusCodePages();
        //    app.UseBrowserLink();
        //    app.UseStaticFiles();
        //    app.UseMvcWithDefaultRoute();
        //}
    }
}
