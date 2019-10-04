using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace UrlsAndRoutes.Infrastructure
{
    public class WeekDayConstraint : IRouteConstraint
    {
        protected virtual IEnumerable<string> Days { get; set; } = new string[]
            {
                "mon",
                "tue",
                "wed",
                "thu",
                "fri",
                "sat",
                "sun"
            };

        public virtual bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return Days.Contains<string>(values[routeKey]?.ToString().ToLower());
        }
    }
}
