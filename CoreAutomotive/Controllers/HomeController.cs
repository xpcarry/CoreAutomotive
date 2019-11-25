using System.Linq;
using System.Threading.Tasks;
using CoreAutomotive.Models;
using CoreAutomotive.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace CoreAutomotive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _CarRepository;
        private readonly UserManager<UserData> _userManager;

        public HomeController(ICarRepository CarRepository, UserManager<UserData> userManager)
        {
            //_CarRepository = new PowerkCarRepository();
            //services.AddTransit, PowerkCarrepository (wskrzykniecie konstruktora)
            _CarRepository = CarRepository;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var Cars = _CarRepository.GetAllCars().OrderBy(s => s.Brand);
            var homeVM = new HomeVM()
            {
                Tytul = "Cars Overview",
                Cars = Cars.ToList()
                
            };

            return View(homeVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var car = _CarRepository.GetCarById(id);
            if (car == null) return NotFound();
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == car.UserId);
            if (user == null) return NotFound();

            var vm = new CarDetailsVM
            {
                Car = car,
                UserName = user.UserName,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Email = user.Email,
                DateJoined = user.DateJoined

            };
            return View(vm);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Contact(string Message, string toUser)
        {
            //var toUser = UserName;
            var fromUser = await _userManager.GetUserAsync(HttpContext.User);
            

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Message) && toUser != null && fromUser != null)
                {
                    //send e-mail, redirect to "EmailSent"
                    System.Console.WriteLine("success");
                }
            }


            return RedirectToAction("Index", "Home");
        }
    }
}
