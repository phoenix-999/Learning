using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseMiddleware
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder app, string pattern)
        {
            app.UseMiddleware<TokenMiddleware>(pattern);
            return app;
        }
    }
}
