using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing.Constraints;
using UrlsAndRoutes.Infrastructure;
using Microsoft.AspNetCore.Routing;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<RouteOptions>(options => {
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routing =>
            //{
            //    //routing.MapRoute(name: "ShopSchema2", template: "Shop/OldAction", defaults: new { controller = "Home", action = "Index" });
            //    //routing.MapRoute(name: "ShopSchema", template: "Shop/{action}", defaults: new { controller = "Home"});
            //    //routing.MapRoute("", "X{controller=Home}/{action=Index}");
            //    //routing.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
            //    //routing.MapRoute(name: "", template: "Public/{controller=Home}/{action=Index}");

                
            //    routing.MapRoute(name: "MyRouteHome", template: "{controller:regex(^H.*)=Home}/{action:regex(^Index$|^About$)=Index}/{id:alpha:minlength(2)?}");

            //    //Собственные специальные ограничения
            //    //routing.MapRoute(name: "WeekDay", template: "{controller}/{action}/{id?}", defaults: new { controller = "Customer", action = "List" }, constraints: new { controller = new RegexRouteConstraint("^Customer$"), id = new WeekDayConstraint() });
            //    routing.MapRoute(name: "WeekDay", template: "{controller:regex(^Customer$)=Customer}/{action=List}/{id:weekday?}"); //то же, что и предыдущий маршрут

            //    //routing.MapRoute(name: "MyRouteAll", template: "{controller}/{action}/{id?}/{*catchall}", defaults: new { controller = "Home", action = "Index"}, constraints: new { id = new IntRouteConstraint() });

            //});
        }
    }
}
