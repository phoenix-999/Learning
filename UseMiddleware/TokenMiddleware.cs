using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseMiddleware
{
    public class TokenMiddleware
    {
        RequestDelegate _next;
        string _pattern;

        public TokenMiddleware(RequestDelegate next, string pattern)
        {
            this._next = next;
            this._pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext httpctx)
        {
            if (!httpctx.Request.Query.ContainsKey("token") || httpctx.Request.Query["token"] != _pattern)
            {
                await httpctx.Response.WriteAsync("Invalid token");
                return;
            }

            await _next(httpctx);
        }
    }
}
