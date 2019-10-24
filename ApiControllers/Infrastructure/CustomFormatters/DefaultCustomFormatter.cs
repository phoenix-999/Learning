using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Reflection;
using System.Text;
using Microsoft.Net.Http.Headers;

namespace ApiControllers.Infrastructure.CustomFormatters
{
    public class DefaultCustomFormatter : OutputFormatter//Если реализовать интерфейс IOutputFormatter, свойство SupportedMediaTypes не будет доступно.
    {
        public DefaultCustomFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/custom"));//Обозначает тип контента для передачи в аттрибут Produced
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            Type type = context.ObjectType;
            PropertyInfo[] data = type.GetProperties();

            StringBuilder builder = new StringBuilder();
            builder.Append("START");
            builder.Append(Environment.NewLine);
            foreach (var p in data)
            {
                builder.AppendFormat($@"'{p.Name}:{p.GetValue(context.Object)}");
                builder.Append(Environment.NewLine);
            }
            builder.Append("FINISH");

            byte[] bytes = Encoding.UTF8.GetBytes(builder.ToString());

            return context.HttpContext.Response.Body.WriteAsync(bytes).AsTask();
        }
    }

}
