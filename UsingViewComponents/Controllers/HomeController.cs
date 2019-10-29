using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponents.Models;

namespace UsingViewComponents.Controllers
{
    public class HomeController : Controller
    {
        IProductRepository repository;
        public HomeController(IProductRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.Products);
        }

        public void Create() => View();

        [HttpPost]
        public void Create(Product newProduct)
        {
            repository.AddProduct(newProduct);
            RedirectToAction("Index");
        }


    }
}
