using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection; 

    namespace ConfiguringApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostContext, configBuilder)=>
                {
                    var env = hostContext.HostingEnvironment;
                    configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                configBuilder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    configBuilder.AddEnvironmentVariables();
                    if (args != null)
                        configBuilder.AddCommandLine(args);
                })
            .ConfigureLogging((hostContext, loggingBuilder) =>
                {
                    loggingBuilder.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                })
            .UseIISIntegration()
            .UseDefaultServiceProvider((hostBuilderContext, options) =>
                {
                    options.ValidateScopes = hostBuilderContext.HostingEnvironment.IsDevelopment();
                })
            .UseStartup(nameof(ConfiguringApps));
    }
}
