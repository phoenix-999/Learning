using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjection.Models;

namespace DependencyInjection
{
    public class Startup
    {
        IHostingEnvironment _env;

        public Startup(IHostingEnvironment  hostingEnvironment)
        {
            _env = hostingEnvironment;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository>(provider => {
                if (_env.IsDevelopment())
                    return provider.GetRequiredService<MemoryRepository>();
                else
                    return provider.GetRequiredService<MemoryRepository>();//В любом случае результат один. Роли не играет.
            });
            services.AddTransient<MemoryRepository>();//Зависимости MemoryRepository будут учтены поставщиом служб
            services.AddTransient<IModelStorage, DictionaryStorage>();
            services.AddTransient<ProductTotalizer>();
            services.AddMvc();
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
