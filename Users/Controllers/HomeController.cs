using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Users.Models;

namespace Users.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        UserManager<AppUser> userManager;
        public HomeController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        private Task<AppUser> CurrentUser => userManager.FindByNameAsync(User.Identity.Name);
        public IActionResult Index()
        {
            return View(GetData(nameof(Index)));
        }

        [Authorize(Policy = "DCUsers")]
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
                ["In Users role"] = User.IsInRole("Users"),
                ["City"] = CurrentUser.Result.City,
                ["Qualifications"] = CurrentUser.Result.Qualifications
            };

            return result;
        }

        public async Task<IActionResult> UserProps() => View(await CurrentUser);

        [HttpPost]
        public async Task<IActionResult> UserProps([Required] Cities city, [Required] QualificationLevel qualifications)
        {
            if (!ModelState.IsValid)
                return View(await CurrentUser);
            AppUser user = await userManager.FindByIdAsync(CurrentUser.Result.Id);
            if (user == null)
                return NotFound("User is not found");
            user.City = city;
            user.Qualifications = qualifications;
            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "NotBob")]
        public IActionResult NotBob() => View("Index", GetData(nameof(NotBob)));
    }
}