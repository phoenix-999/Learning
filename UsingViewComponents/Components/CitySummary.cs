using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using UsingViewComponents.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        ICityRepository _repo;
        public CitySummary(ICityRepository repository)
        {
            _repo = repository;
        }

        public ViewViewComponentResult Invoke()
        {
            return View(_repo.Cities);
        }
    }
}
