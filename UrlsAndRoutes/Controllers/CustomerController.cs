using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;
using Microsoft.AspNetCore.Mvc.Routing;

namespace UrlsAndRoutes.Controllers
{
    [Route("app/[controller]/actions/[action]/{id:weekday?}")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View("Result", new Result { Controller = nameof(CustomerController), Action = nameof(Index)});
        }

        public IActionResult List(string id)
        {
            Result r = new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            };
            r.Data["Id"] = id ?? "<not value>";
            r.Data["catchall"] = RouteData.Values["catchall"];

            return View("Result", r);
        }
    }
}