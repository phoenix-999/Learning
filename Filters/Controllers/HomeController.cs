using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    //[RequireHttps]
    [HttpsOnly]
    [Profile]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Message", "This is Index action from Home controller");
        }
    }
}