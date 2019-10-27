using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Filters.Infrastructure
{
    public class ProfileAttribute : ActionFilterAttribute
    {
        Stopwatch timer;

        double actionTime;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }


        public override void OnActionExecuted(ActionExecutedContext context)
        {
            actionTime = timer.Elapsed.TotalMilliseconds;
            //context.ExceptionHandled = true;
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();//выполнения обработки результата действия инфраструктурой MVC

            timer.Stop();

            string result = $"<div>Action time = {actionTime} ms</div" +
                $"<div>Total tile = {timer.Elapsed.TotalMilliseconds}";

            byte[] bytes = Encoding.UTF8.GetBytes(result);

            await context.HttpContext.Response.Body.WriteAsync(bytes);
        }
    }
}
