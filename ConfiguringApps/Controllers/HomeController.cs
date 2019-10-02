using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptimeService;

        private ILogger<HomeController> logger;

        public HomeController(UptimeService uptimeService, ILogger<HomeController> log)
        {
            this.uptimeService = uptimeService;
            this.logger = log;
        }

        public IActionResult Index(bool throwException = false)
        {
            logger.LogDebug($"Handled {Request.Path} at uptime {uptimeService.Uptime}");
            if (throwException)
            {
                throw new NullReferenceException();
            }

            return View(new Dictionary<string, string>
            {
                { "Message", "This is the Index action" },
                { "Uptime", $"{uptimeService.Uptime}ms"}
            });
        }

        public IActionResult Error()
        {
            return View(
                nameof(Index),
                new Dictionary<string, string>
                    {
                        {"Message", "This is the Error action" }
                    });
        }
    }
}
