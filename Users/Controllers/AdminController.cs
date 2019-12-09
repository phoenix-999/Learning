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
        IPasswordValidator<AppUser> passwordValidator;
        IUserValidator<AppUser> userValidator;
        public AdminController(UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher, IPasswordValidator<AppUser> passwordValidator, IUserValidator<AppUser> userValidator)
        {
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
            this.passwordValidator = passwordValidator;
            this.userValidator = userValidator;
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

        public async Task<IActionResult> Edit(string userId)
        {
            AppUser user = await userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string password)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            user.Email = email;
            IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);
            if(!validEmail.Succeeded)
            {
                AddErrorFromResult(validEmail);
            }
            if(!string.IsNullOrEmpty(password))
            {
                IdentityResult validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                if (!validPass.Succeeded)
                    AddErrorFromResult(validPass);
                else
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, password);
                }
            }
            if (ModelState.IsValid)
            {
                IdentityResult result = await userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
                
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();
            IdentityResult result = await userManager.DeleteAsync(user);
            if(!result.Succeeded)
            {
                AddErrorFromResult(result);
            }
            return View("Index", userManager.Users);
        }

        private void AddErrorFromResult(IdentityResult result)
        {
            foreach(var er in result.Errors)
            {
                ModelState.AddModelError("", er.Description);
            }
        }
    }
}