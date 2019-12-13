using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Models;
using Microsoft.AspNetCore.Identity;

namespace Users.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        UserManager<AppUser> userManager;
        SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        //[IgnoreAntiforgeryToken] //Нужен при включенном ValidateAntiForgeryTokenAttribute
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel details, string returnUrl)
        {
            if(!ModelState.IsValid)
            {
                return View(details);
            }
            AppUser user = await userManager.FindByEmailAsync(details.Email);
            if(user == null)
            {
                ModelState.AddModelError("", "User is not found");
                return View(details);
            }
            await signInManager.SignOutAsync();
            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, details.Password, false, false);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid user or password");
                return View(details);
            }
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction(controllerName: "Home", actionName: "Index");
            }

            return Redirect(returnUrl);

        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}