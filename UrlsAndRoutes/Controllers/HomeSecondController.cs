using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;
using Microsoft.AspNetCore.Mvc.Routing;

namespace UrlsAndRoutes.Controllers
{
    public class HomeSecondController : Controller
    {
        public IActionResult Index()
        {
            return View("Result", new Result { Controller = nameof(HomeSecondController), Action = nameof(Index)});
        }

        public IActionResult CustomValidate(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeSecondController),
                Action = nameof(CustomValidate)
            };

            r.Data["Id"] = id ?? "<no value>";

            return View("Result", r);
        }
    }
}