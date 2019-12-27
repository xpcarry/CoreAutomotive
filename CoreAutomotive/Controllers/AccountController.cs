using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAutomotive.Models;
using CoreAutomotive.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
                var addUser = await _userManager.CreateAsync(user, registerVM.Password);

                if (addUser.Succeeded)
                {
                    var result = await _userManager.AddToRoleAsync(user, "User");
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                            return Redirect(returnUrl);
                        else
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
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
        public async Task<IActionResult> MyProfile(string message)
        {
            ViewBag.Message = message;
            //var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var user = await GetCurrentUserAsync();
            var userId = user.Id;
            var myCars = _context.Cars.Where(c => c.UserId == userId);
            var myPictures = _context.Pictures.Where(p => p.UserId == userId).ToList();

            var vm = new MyProfileVM()
            {
                User = user,
                CarAmount = _context.Cars.Where(c => c.UserId == userId).Count(),
                MyCars = myCars,
                Pictures = myPictures
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditMyProfile(MyProfileVM profileEdit)
        {
            if (profileEdit == null)
            {
                ViewBag.ErrorMessage = "Something went wrong :(";
                return View("NotFound");
            }


            var user = await GetCurrentUserAsync();
            var updatedUser = profileEdit.User;

            if (!string.IsNullOrEmpty(profileEdit.NewPassword) && profileEdit.NewPassword == profileEdit.NewPasswordConfirm)
            {
                var newPassword = _userManager.PasswordHasher.HashPassword(user, profileEdit.NewPassword);
                user.PasswordHash = newPassword;
                var resultPassword = await _userManager.UpdateAsync(user);

                if (resultPassword.Succeeded)
                    return RedirectToAction("MyProfile", new { message = "You have updated your password!"});
                else
                {
                    ViewBag.ErrorMessage = $"Unable to load user with ID {user.Id}";
                    return NotFound();
                }
            }

            if (updatedUser != null)
            {

                if (!string.IsNullOrEmpty(updatedUser.Email) && (user.Email != updatedUser.Email))
                {
                    user.Email = updatedUser.Email;
                    var resultEmail = await _userManager.UpdateAsync(user);
                    if (resultEmail.Succeeded)
                        return RedirectToAction("MyProfile", new { message = "You have updated your e-mail address!"});
                    else
                    {
                        ViewBag.ErrorMessage = $"Unable to load user with ID {user.Id}";
                        return NotFound();
                    }
                }


                if (!string.IsNullOrEmpty(updatedUser.Name) && (user.Name != updatedUser.Name))
                {
                    user.Name = updatedUser.Name;
                }
                if (!string.IsNullOrEmpty(updatedUser.Surname) && (user.Surname != updatedUser.Surname))
                {
                    user.Surname = updatedUser.Surname;
                }
                if (!string.IsNullOrEmpty(updatedUser.City) && (user.City != updatedUser.City))
                {
                    user.City = updatedUser.City;
                }
                if (!string.IsNullOrEmpty(updatedUser.PhoneNumber) && (user.PhoneNumber != updatedUser.PhoneNumber))
                {
                    user.PhoneNumber = updatedUser.PhoneNumber;
                }

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("MyProfile", new { message = "You have updated your personal data!" });
                }
            }

            return RedirectToAction("MyProfile");
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
                CarsAmount = _context.Cars.Where(c => c.UserId == user.Id).Count(),
                UserPictures = _context.Pictures.Where(p => p.UserId == user.Id).ToList(),
                City = user.City
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManageUsers()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            if (roles == null)
            {
                ViewBag.ErrorMessage = "Any roles cannot be found";
                return View("NotFound");
            }

            var vm = new ManageUsersVM()
            {
                Roles = new List<Role>(),
                UsersWithRoles = new List<UsersWithRoles>(),
            };

            vm.Roles.AddRange(roles);

            foreach (var role in roles)
            {
                foreach (var user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        var usersRoles = new UsersWithRoles()
                        {
                            UserName = user.UserName,
                            RoleName = role.Name,
                            RoleId = role.Id,
                            UserId = user.Id
                        };
                        vm.UsersWithRoles.Add(usersRoles);
                    }
                }

            }

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUsersInRole(int id)
        {
            ViewBag.roleId = id;
            var role = await _roleManager.FindByIdAsync(id.ToString());
            ViewBag.RoleName = role.Name;

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var vm = new List<UsersWithRoles>();

            foreach (var user in _userManager.Users)
            {
                var userRole = new UsersWithRoles
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                    userRole.IsSelected = true;
                else
                    userRole.IsSelected = false;

                vm.Add(userRole);
            }

            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUsersInRole(List<UsersWithRoles> userRoles, string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            int i = 0;
            foreach (var item in userRoles)
            {
                i++;
                IdentityResult result = null;
                var user = await _userManager.FindByIdAsync(item.UserId.ToString());

                if (item.IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                else if (!item.IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                else continue;

                if (result.Succeeded)
                {
                    if (i < (userRoles.Count - 1))
                        continue;
                    else
                        return RedirectToAction("ManageUsers");
                }
            }
            return RedirectToAction("ManageUsers");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}