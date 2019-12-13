using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Users.Models;

namespace Users.Controllers
{
    public class RoleAdminController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<AppUser> userManager;

        public RoleAdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
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


        public async Task<IActionResult> Edit(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
                return NotFound(roleId);
            List<AppUser> members = new List<AppUser>();
            List<AppUser> nonMembers = new List<AppUser>();
            foreach(AppUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEditViewModel {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleModificationViewModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach(string userId in model.IdsToAdd ?? new string[] { })
                {
                    AppUser user = await userManager.FindByIdAsync(userId);
                    if(user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if(!result.Succeeded)
                        {
                            AddErrorFromResult(result);
                        }
                    }
                }

                foreach(string userId in model.IdsToDelete ?? new string[] { })
                {
                    AppUser user = await userManager.FindByIdAsync(userId);
                    if(user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if(!result.Succeeded)
                        {
                            AddErrorFromResult(result);
                        }
                    }
                }
            }
            if(ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return await Edit(model.RoleId);
            }

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