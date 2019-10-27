using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views.Infrastructure
{
    public class DebugDataView : IView
    {
        public string Path => string.Empty;

        public async Task RenderAsync(ViewContext context)
        {
            context.HttpContext.Response.ContentType = @"text/plain";

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("------Route data------------");
            foreach(var kvp in context.RouteData.Values)
            {
                builder.AppendLine($"Key: {kvp.Key}, value: {kvp.Value}");
            }

            builder.AppendLine("------View data------------");
            foreach(var kvp in context.ViewData)
            {
                builder.AppendLine($"Key: {kvp.Key}, value: {kvp.Value}");
            }

            await context.Writer.WriteAsync(builder.ToString());
        }
    }
}
