using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Users.Models;

namespace Users.Controllers
{
    public class AdminController : Controller
    {
        UserManager<AppUser> userManager;
        IPasswordHasher<AppUser> passwordHasher;
        public AdminController(UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher)
        {
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
        }


        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUser createUser)
        {
            if (!ModelState.IsValid)
                return View(createUser);

            AppUser newUser = new AppUser()
            {
                UserName = createUser.Name,
                Email = createUser.Email
            };
            //newUser.PasswordHash = passwordHasher.HashPassword(newUser, createUser.Password);// Пароль будет хеширован и установлен пользователю без проверки требований к паролю. Принудительная установка пароля.
            IdentityResult result = await userManager.CreateAsync(newUser, createUser.Password);//Пароль будет хешироваться с предварительной проверкой к требованиям к паролю
            if (result.Succeeded)
                return await Task.FromResult<IActionResult>(RedirectToAction("Index"));
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(createUser);
            }
        }
    }
}