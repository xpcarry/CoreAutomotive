using System.Linq;
using System.Threading.Tasks;
using CoreAutomotive.Models;
using CoreAutomotive.Services;
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
        private readonly IEmailService _emailService;
        private readonly IPictureRepository _pictureRepository;

        public HomeController(ICarRepository CarRepository, UserManager<UserData> userManager, IEmailService emailService , IPictureRepository pictureRepository)
        {
            //_CarRepository = new PowerkCarRepository();
            //services.AddTransit, PowerkCarrepository (wskrzykniecie konstruktora)
            _CarRepository = CarRepository;
            _userManager = userManager;
            _emailService = emailService;
            _pictureRepository = pictureRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var pictures = _pictureRepository.GetAllPictures();
            var Cars = _CarRepository.GetAllCars().OrderBy(s => s.Brand);
            var homeVM = new HomeVM()
            {
                Tytul = "Cars Overview",
                Cars = Cars.ToList(),
                Pictures = pictures.ToList()
                
            };

            return View(homeVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var car = _CarRepository.GetCarById(id);
            if (car == null) return NotFound();
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == car.UserId);
            if (user == null) return NotFound();

            var pictures = _pictureRepository.GetPicturesByCarId(id).ToList();

            var vm = new CarDetailsVM
            {
                Car = car,
                UserName = user.UserName,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Email = user.Email,
                DateJoined = user.DateJoined,
                ReturnUrl = HttpContext.Request.Host.ToString() + HttpContext.Request.Path.ToString(),
                Pictures = pictures

            };
            return View(vm);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Contact(CarDetailsVM vm)
        {
            var fromUser = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(vm.Message) && !string.IsNullOrEmpty(vm.Email) && fromUser != null)
                {
                    var car = new Car();
                    car.Id = vm.Car.Id;
                           

                    var subject = "You have the new message from " + fromUser.UserName.ToString();
                    await _emailService.SendEmailAsync(vm.Email, vm.Message, subject);
                    return RedirectToAction(nameof(MessageSent), car);

                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult MessageSent(Car car)
        {
            ViewBag.CarId = car.Id;
            return View();
        }
    }
}
