using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Filters.Infrastructure
{
    public class DefaultDiagnosticsFilter : IActionFilter, IResultFilter
    {
        IDiagnostics diagnostics;

        Stopwatch timer;

        public DefaultDiagnosticsFilter(IDiagnostics diagnostics)
        {
            this.diagnostics = diagnostics;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string controllerName = context.Controller.ToString();
            string actionName = context.ActionDescriptor.DisplayName;
            diagnostics.AddData($@"Action {actionName} in controller {controllerName} worked: {timer.Elapsed.TotalMilliseconds}ms ");
        }


        public void OnResultExecuting(ResultExecutingContext context)
        {
            ViewResult vr = context.Result as ViewResult;
            if (vr != null)
            {
                context.Result = new ViewResult
                {
                    ViewName = "DiagnosticsMessage",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                       Model = diagnostics.Data
                    }
                };
            }
        }


        public async void OnResultExecuted(ResultExecutedContext context)
        {
            timer.Stop();

            string controllerName = context.Controller.ToString();
            string actionName = context.ActionDescriptor.DisplayName;
            string message = $@"<div>Last result time {actionName} in controller {controllerName}: {timer.Elapsed.TotalMilliseconds}ms</div>";
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await context.HttpContext.Response.Body.WriteAsync(bytes);
        }

    }
}
