using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControllersAndActions.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        IHostingEnvironment _env;

        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "Infrastructure", "htmlpage.html");
            Stream fileStream = System.IO.File.OpenRead(filePath);
            return File(fileStream, "text/plain");//Передаст поток. При передаче имени файла сохранит файл на клиенте.
            //return PhysicalFile(filePath, "text/plain", "htmlpage.html"); //При передаче имени файла сохранит файл на клиенте
            //return File("lib/bootstrap/readme.md", "text/plain");//Корневым каталогом для VirtualFileREsult  являеться wwwroot.При передаче имени файла сохранит файл на клиенте

            //return Ok(new string[] { "Alice", "Bob", "Joe" }); // С учетом согласования содержимого
            //return Content("[\"Alice\", \"Bob\", \"Joe\"]", "application/json");
            //return Json(new string[] { "Alice", "Bob", "Joe" });
            //return View("SimpleForm");
        }

        [HttpPost]
        public IActionResult ReceiveForm(string name, string city)
        {
            TempData["name"] = name;
            TempData["city"] = city;
            return RedirectToAction(nameof(Data));
            //return View("Result", $"{name} lives in {city}");
            //return new CustomHtmlResult { Content = $"{name} lives in {city}" };
        }

        public IActionResult Data()
        {
            string name, city;
            name = TempData["name"] as string;
            city = TempData["city"] as string;

            return View("Result", $"{name} lives in {city}");
        }

    }
}