using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiControllers.Models;

namespace ApiControllers.Controllers
{
    public class HomeController : Controller
    {
        IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.Reservations);
        }

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            repository.AddOrUpdateReservation(reservation);
            return RedirectToAction("Index");
        }
    }
}