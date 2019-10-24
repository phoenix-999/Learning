using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiControllers.Infrastructure.CustomFormatters
{
    public static class FormattersExtensions
    {
        public static IMvcBuilder AddDefaultCustomFormatter(this IMvcBuilder builder)
        {
            builder.AddMvcOptions(options =>
            {
                options.OutputFormatters.Add(new DefaultCustomFormatter());
            });

            return builder;
        }
    }
}
