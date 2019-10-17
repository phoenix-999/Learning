using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace Filters.Infrastructure
{
    public class ProfileAttribute : Attribute, IActionFilter //или можно наследовать от ActionFilterAttribute и переопредлить те же методы
    {
        Stopwatch timer;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();

            var message = $"<div>Elapsed time: {timer.ElapsedMilliseconds}</div>";
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            context.HttpContext.Response.Body.Write(bytes);
        }
    }
}
