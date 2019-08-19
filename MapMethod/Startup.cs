using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MapMethod
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/Index", Index);
            app.Map("", OtherPage);
        }

        void Index(IApplicationBuilder app)
        {
            app.Map("/InnerPage", index =>
                {
                    index.Run(async httpctx =>
                        {
                            await httpctx.Response.WriteAsync("Index/InnerPage");
                        });
                });

            app.Run(async httpctx =>
                {
                    await httpctx.Response.WriteAsync("Index");
                });
        }

        void OtherPage(IApplicationBuilder app)
        {
            app.MapWhen(httpctx =>
                {
                    return httpctx.Request.Query.ContainsKey("id") && httpctx.Request.Query["id"] == "5";
                }, Home);

            app.Run(async httpctx =>
            {
                await httpctx.Response.WriteAsync("Other Page");
            });
        }

        void Home(IApplicationBuilder app)
        {
            app.Run(async httpctx =>
            {
                await httpctx.Response.WriteAsync("Home Page");
            });
        }
    }
}
