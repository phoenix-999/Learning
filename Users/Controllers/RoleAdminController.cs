using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Users.Controllers
{
    public class RoleAdminController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RoleAdminController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (!ModelState.IsValid)
                return View((object)name);
            IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
            if(result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                AddErrorFromResult(result);
                return View((object)name);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("", "Role Id is null or empty");
                return View(nameof(Index), roleManager.Roles);
            }
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ModelState.AddModelError("", "Role not found");
                return View(nameof(Index), roleManager.Roles);
            }
            IdentityResult result = await roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                AddErrorFromResult(result);
                return View(nameof(Index), roleManager.Roles);
            }
            return RedirectToAction(nameof(Index));
        }

        private void AddErrorFromResult(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}