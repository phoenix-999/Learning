using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConfiguringApps.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate next;

        public BrowserTypeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            ctx.Items["EdgeBrowser"] = ctx.Request.Headers["UserAgent"].Any(h => h.ToLower().Contains("edge"));
            await next.Invoke(ctx);
        }
    }
}
