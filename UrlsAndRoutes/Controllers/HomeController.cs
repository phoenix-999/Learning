using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;
using Microsoft.AspNetCore.Mvc.Routing;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Result", new Result { Controller = nameof(HomeController), Action = nameof(Index)});
        }

        public IActionResult CustomValidate(string id, string other)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomValidate)
            };

            r.Data["Id"] = id ?? "<no value>";
            r.Data["Other"] = other ?? "<no value>";
            r.Data["Url"] = Url.Action("CustomValidate", "Home", new { id = 5, other = "other"});

            return View("Result", r);
        }
    }
}