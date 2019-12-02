using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreAutomotive.Models;
using CoreAutomotive.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            var Pictures = _pictureRepository.GetAllPictures();
            var Cars = _carRepository.GetAllCars();
            return View(Cars);
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

        public IActionResult Create()
        {
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
                return RedirectToAction(nameof(Index));
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


        //Doweryfikacji
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

                return RedirectToAction(nameof(Index));
            }
            return View(Car);
        }

        //[HttpPost]
        //public async Task<IActionResult> FileUpload(IFormCollection form)
        //{
        //    var webRoot = _env.WebRootPath;
        //    var filePath = Path.Combine(webRoot.ToString() + "\\images\\" + form.Files[0].FileName);

        //    if (form.Files[0].FileName.Length > 0)
        //    {
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await form.Files[0].CopyToAsync(stream);
        //        }
        //    }
        //    if (Convert.ToString(form["Id"]) == string.Empty || Convert.ToString(form["Id"]) == "0")
        //    {
        //        return RedirectToAction("Create", new {FileName = Convert.ToString(form.Files[0].FileName) });
        //    }
        //    else
        //    {
        //        return RedirectToAction("Edit", new { FileName = Convert.ToString(form.Files[0].FileName), id = Convert.ToString(form["Id"]) });
        //    }
        //}


        
    }
}