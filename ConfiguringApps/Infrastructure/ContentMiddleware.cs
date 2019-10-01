using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using ConfiguringApps.Infrastructure;

namespace ConfiguringApps.Infrastructure
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private UptimeService uptime;

        public ContentMiddleware(RequestDelegate next, UptimeService uptime)
        {
            nextDelegate = next;
            this.uptime = uptime;
        }

        public async Task Invoke(HttpContext ctx)
        {
            if (ctx.Request.Path.ToString().ToLower() == "/middleware")
            {
                await ctx.Response.WriteAsync("This is from the content middleware." + $" Uptime = {uptime.Uptime}", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(ctx);
            }
        }
    }
}
