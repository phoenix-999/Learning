using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptimeService;

        public HomeController(UptimeService uptimeService)
        {
            this.uptimeService = uptimeService;
        }

        public IActionResult Index(bool throwException = false)
        {
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
