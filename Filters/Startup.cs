using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthorizationFilter, HttpsOnlyAttribute>();
            services.AddSingleton<IDiagnostics, ConcurrentDiagnostics>();

            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.AddService(typeof(IAuthorizationFilter)); //Глобальный фильтр с поддержкой зависимостей. Поставщик служб обнаружит класс реализации в другом месте метода ConfigureServices
            });

            //services.AddMvc().AddMvcOptions(options =>
            //{
            //    options.Filters.Add(typeof(HttpsOnlyAttribute)); //Глобальный фильтр без поддержки зависимостей. Поставщик служб не работает.
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
