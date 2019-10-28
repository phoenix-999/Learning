using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.Message = "Hello, World!";
            //ViewBag.CurrentTime = DateTime.Now;
            //return View("DebugData");

            return View();
        }

        public IActionResult List() => View();
    }
}