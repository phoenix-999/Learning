using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public IActionResult Result()
        {
            return View((object)"Hello, World!");
        }

        public IActionResult Redirect()
        {
            //return Redirect($"/Example/{nameof(Index)}");
            //return LocalRedirect($"https://translate.google.com/#view=home&op=translate&sl=en&tl=ru&text=permanent");
            return RedirectToRoute(new { controller = "Example", action = "Index", id = "MyID" });
        }
    }
}