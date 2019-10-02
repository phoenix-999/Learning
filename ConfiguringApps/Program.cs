using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
                    configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    configBuilder.AddEnvironmentVariables();
                    if (args != null)
                        configBuilder.AddCommandLine(args);
                })
            .UseIISIntegration()
            .UseStartup<Startup>();
    }
}
