using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        IRepository _repository;
        //ProductTotalizer _totalizer;

        public HomeController(IRepository repository)//, ProductTotalizer productTotalizer)
        {
            _repository = repository;
            //_totalizer = productTotalizer;
        }

        public IActionResult Index([FromServices]ProductTotalizer _totalizer)
        {
            ViewData["Total"] = _totalizer.Total;
            ViewBag.Total = _totalizer.Total;
            return View(_repository.Products);
        }
    }
}