using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View(GetData(nameof(Index)));
        }

        [Authorize(Roles = "Users")]
        public IActionResult OtherAction()
        {
            return View(nameof(Index), GetData(nameof(OtherAction)));
        }

        private Dictionary<string, object> GetData(string actionName)
        {
            Dictionary<string, object> result = new Dictionary<string, object>
            {
                ["Action name"] = actionName,
                ["User"] = User.Identity.Name,
                ["Authenticated"] = User.Identity.IsAuthenticated,
                ["Auth type"] = User.Identity.AuthenticationType,
                ["In Users role"] = User.IsInRole("Users")
            };

            return result;
        }
    }
}