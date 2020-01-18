using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CoreAutomotive.Models;
using CoreAutomotive.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreAutomotive.Controllers
{
    [Authorize]
    public class CarController : Controller
    {

        private readonly ICarRepository _carRepository;
        private IWebHostEnvironment _env;
        private readonly IPictureRepository _pictureRepository;
        private readonly UserManager<UserData> _userManager;

        public CarController(ICarRepository CarRepository, IWebHostEnvironment env, IPictureRepository pictureRepository, UserManager<UserData> userManager)
        {
            _carRepository = CarRepository;
            _env = env;
            _pictureRepository = pictureRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var cars = _carRepository.GetAllCars();
            var pictures = _pictureRepository.GetAllPictures();
            return View(cars);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            var Pictures = _pictureRepository.GetAllPictures();
            var cars = _carRepository.GetAllCars().ToList();
            return View(cars);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Manage(List<Car> cars)
        {

            if (cars == null)
            {
                ViewBag.ErrorMessage = $"Any car cannot be found";
                return View("NotFound");
            }

            int i = 0;
            foreach (var item in cars)
            {
                i++;
                var car = _carRepository.GetCarById(item.Id);
                if (item.Featured && !car.Featured)
                {
                    car.Featured = true;
                    _carRepository.EditCar(car);
                }
                else if (!item.Featured && car.Featured)
                {
                    car.Featured = false;
                    _carRepository.EditCar(car);
                }
                else continue;

                if (i < cars.Count - 1)
                    continue;
                else
                    RedirectToAction("Manage");
            }
            return RedirectToAction("Manage");
        }

        public IActionResult Details(int id)
        {
            var pictures = _pictureRepository.GetPicturesByCarId(id);
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        //public IActionResult Create(string FileName)
        //{
        //    if (!string.IsNullOrEmpty(FileName))
        //        ViewBag.ImgPath = "/Images/" + FileName;

        //    return View();
        //}

        public async Task<IActionResult> Create(bool migrate)
        {
            if (migrate)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("http://localhost:6000/api/Car");
                    if (response.IsSuccessStatusCode)
                    {
                        var result = client.GetStringAsync("http://localhost:6000/api/Car");

                        var json = await result;

                        Car car = JsonConvert.DeserializeObject<Car>(json);
                        var vm = new CarVM()
                        {
                            Car = car
                        };
                        return View(vm);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMsg = ex.Message;
                }

            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarVM vm)
        {
            if (ModelState.IsValid)
            {
                var car = vm.Car;
                var user = await _userManager.GetUserAsync(HttpContext.User);

                car.UserId = user.Id;
                car.UserName = user.UserName;
                car.DateAdded = DateTime.Now;
                _carRepository.AddCar(car);
                return RedirectToAction("AddPictures", "Pictures", new { carId = Convert.ToString(car.Id) });
            }

            return View(vm);
        }

        public IActionResult Edit(int id, string FileName)
        {
            var car = _carRepository.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarVM
            {
                Car = car,
                Pictures = _pictureRepository.GetPicturesByCarId(id),
            };

            if (!string.IsNullOrEmpty(FileName))
                ViewBag.ImgPath = "/Images/" + FileName;
            //            else ViewBag.ImgPath = Car.PictureUrl;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarVM vm)
        {
            if (ModelState.IsValid)
            {
                _carRepository.EditCar(vm.Car);
                return RedirectToAction(nameof(Manage));
            }
            return View(vm);
        }


        public IActionResult Delete(int id)
        {
            var car = _carRepository.GetCarById(id);
            var pictures = _pictureRepository.GetPicturesByCarId(id);

            if (car == null)
                return NotFound();
            var vm = new CarVM
            {
                Car = car,
                Pictures = pictures
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Car Car)
        {
            if (ModelState.IsValid)
            {
                //delete pictures
                var webRoot = _env.WebRootPath;
                var pictures = _pictureRepository.GetPicturesByCarId(Car.Id);
                if (pictures != null && pictures.Count > 0)
                {
                    foreach (var pic in pictures)
                    {
                        var filePath = Path.Combine(webRoot.ToString() + pic.PictureUrl);
                        System.IO.File.Delete(filePath);
                    }
                }

                _carRepository.DeleteCar(Car);

                return RedirectToAction(nameof(Manage));
            }
            return View(Car);
        }
    }
}