using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate next;

        public ShortCircuitMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            if (ctx.Items["EdgeBrowser"] as bool? == true)
            {
                ctx.Response.StatusCode = 403;
            }
            else
            {
                await next.Invoke(ctx);
            }
        }
    }
}
