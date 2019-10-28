using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAutomotive.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreAutomotive.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Nazwa użytkownika / hasło jest niepoprawne");

            return View(loginVM);
        }

        // GET: /<controller>/
        public IActionResult Register()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = loginVM.UserName };
                var result = await _userManager.CreateAsync(user, loginVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut(LoginVM loginVM)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }

}