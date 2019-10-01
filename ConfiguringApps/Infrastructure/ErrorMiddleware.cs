using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace ConfiguringApps.Infrastructure
{
    public class ErrorMiddleware
    {
        private RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            await _next.Invoke(ctx);

            if (ctx.Response.StatusCode == 403)
            {
                await ctx.Response.WriteAsync("Edge not supported", Encoding.UTF8);
            }
            else if (ctx.Response.StatusCode == 404)
            {
                await ctx.Response.WriteAsync("No content middleware response", Encoding.UTF8);
            }
        }
    }
}
