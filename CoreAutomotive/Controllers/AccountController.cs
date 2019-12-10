using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAutomotive.Models;
using CoreAutomotive.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreAutomotive.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<UserData> _signInManager;
        private readonly UserManager<UserData> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly AppDbContext _context;


        public AccountController(SignInManager<UserData> signInManager, UserManager<UserData> userManager, AppDbContext context,
            RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string returnUrl)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Nazwa użytkownika / hasło jest niepoprawne");

            return View(loginVM);
        }

        // GET: /<controller>/
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = new UserData()
                {
                    Name = registerVM.Name,
                    Surname = registerVM.Surname,
                    Email = registerVM.Email,
                    PhoneNumber = registerVM.PhoneNumber,
                    City = registerVM.City,
                    UserName = registerVM.Email,
                    DateJoined = DateTime.Now

                };
                var result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }

            return View(registerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut(LoginVM loginVM)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private Task<UserData> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public async Task<IActionResult> MyProfile()
        {
            //var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var user = await GetCurrentUserAsync();
            var userId = user.Id;
            var myCars = _context.Cars.Where(c => c.UserId == userId);
            var myPictures = _context.Pictures.Where(p => p.UserId == userId).ToList();

            var vm = new MyProfileVM()
            {
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                City = user.City,
                DateJoined = user.DateJoined,
                MyCars = myCars,
                Pictures = myPictures
            };

            return View(vm);
        }

        public async Task<IActionResult> ViewProfile(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            var model = new ViewProfile()
            {
                UserName = user.UserName,
                Email = user.Email,
                DateJoined = user.DateJoined,
                UserCars = _context.Cars.Where(c => c.UserId == user.Id).ToList(),
                UserPictures = _context.Pictures.Where(p => p.UserId == user.Id).ToList()
            };

            return View(model);
        }


        public async Task<IActionResult> ManageUsers()
        {
            var roles =  _roleManager.Roles;

            if (roles == null)
            {
                ViewBag.ErrorMessage = "Any roles cannot be found";
                return View("NotFound");
            }

            var vm = new List<ManageUsersVM>();

            foreach (var role in roles)
            {
                foreach (var user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        var userRole = new ManageUsersVM()
                        {
                            UserName = user.UserName,
                            RoleName = role.Name,
                            RoleId = role.Id,
                            UserId = user.Id
                        };
                        vm.Add(userRole);
                    }
                }

            }

            return View(vm);
        }

        //public Task<IActionResult> ManageUsers(ManageUsersVM vm)
        //{
        //    return View(vm);
        //}

        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}