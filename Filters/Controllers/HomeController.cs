using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    //[RequireHttps]
    [Profile] //Так как фильтр дописывает данные в тело ответа на стадии пост обработки, содержимое ответа метода действия будет сохранено
    [ViewResultDetails]
    [RangeException]
    //[TypeFilter(typeof(DefaultDiagnosticsFilter))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Message", "This is Index action from Home controller");
        }

        public IActionResult GenerateException(int id)
        {
            if (id >= 10)
                throw new ArgumentOutOfRangeException(nameof(id));
            else
                return View("Message", $"id = {id}");
        }
    }
}