using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace Filters.Infrastructure
{
    public class ViewResultDetailsAttribute : ResultFilterAttribute//Отработает если нет исключения в методе действия или оно было обработано в фильтре пост действия
    {
        public override async void OnResultExecuting(ResultExecutingContext context)
        {
            Dictionary<string, string> details = new Dictionary<string, string>();

            ViewResult vr = context.Result as ViewResult;

            if (vr != null)
            {
                details["ViewName"] = vr.ViewName;
                details["Model Type"] = vr.Model.GetType().ToString();
                details["Model content"] = vr.Model.ToString();
                details["Is async"] = false.ToString();

                context.Result = new ViewResult
                {
                    ViewName = "Message",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { Model = details }
                };
            }

            string message = $@"OnResultExecuting";
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await context.HttpContext.Response.Body.WriteAsync(bytes);
        }

        //Стандартная реализация асинхронного метода вызывает свои синхронные аналоги
        //public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        //{
        //    Dictionary<string, string> details = new Dictionary<string, string>();

        //    ViewResult vr = context.Result as ViewResult;

        //    if (vr != null)
        //    {
        //        details["ViewName"] = vr.ViewName;
        //        details["Model Type"] = vr.Model.GetType().ToString();
        //        details["Model content"] = vr.Model.ToString();
        //        details["Is async"] = true.ToString();
        //    }

        //    context.Result = new ViewResult
        //    {
        //        ViewName = "Message",
        //        ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { Model = details }
        //    };

        //    await next();
        //}

        public override async void OnResultExecuted(ResultExecutedContext context) 
        {
            string controllerName = context.Controller.ToString();
            string actionName = context.ActionDescriptor.DisplayName;
            string message = $@"OnResultExecuted {context.Result.GetType()}";
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await context.HttpContext.Response.Body.WriteAsync(bytes);
        }
    }
}
