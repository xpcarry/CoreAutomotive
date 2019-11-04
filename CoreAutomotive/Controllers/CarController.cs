using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreAutomotive.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAutomotive.Controllers
{
    public class CarController : Controller
    {

        private readonly ICarRepository _CarRepository;
        private IWebHostEnvironment _env;

        public CarController(ICarRepository CarRepository, IWebHostEnvironment env)
        {
            _CarRepository = CarRepository;
            _env = env;
        }

        public IActionResult Index()
        {
            var Cars = _CarRepository.GetAllCars();
            return View(Cars);
        }

        public IActionResult Details(int id)
        {
            var Car = _CarRepository.GetCarById(id);
            if (Car == null)
            {
                return NotFound();
            }
            return View(Car);
        }

        public IActionResult Create(string FileName)
        {
            if (!string.IsNullOrEmpty(FileName))
                ViewBag.ImgPath = "/Images/" + FileName;
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car Car)
        {
            if (ModelState.IsValid)
            {
                _CarRepository.AddCar(Car);
                return RedirectToAction(nameof(Index));
            }

            return View(Car);
        }

        public IActionResult Edit(int id, string FileName)
        {
            var Car = _CarRepository.GetCarById(id);

            if (Car==null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(FileName))
                ViewBag.ImgPath = "/Images/" + FileName;
            else ViewBag.ImgPath = Car.PictureUrl;

            return View(Car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car Car)
        {
            if (ModelState.IsValid)
            {
                _CarRepository.EditCar(Car);
                return RedirectToAction(nameof(Index));
            }
            return View(Car);
        }


        public IActionResult Delete(int id)
        {
            var Car = _CarRepository.GetCarById(id);

            if (Car == null)
            {
                return NotFound();
            }

            return View(Car);
        }


        //Doweryfikacji
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Car Car, string PictureUrl)
        {
            if (ModelState.IsValid)
            {
                _CarRepository.DeleteCar(Car);

                //delete picture
                if (PictureUrl != null)
                {
                    var webRoot = _env.WebRootPath;
                    var filePath = Path.Combine(webRoot.ToString() + PictureUrl);
                    System.IO.File.Delete(filePath);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Car);
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(IFormCollection form)
        {
            var webRoot = _env.WebRootPath;
            var filePath = Path.Combine(webRoot.ToString() + "\\images\\" + form.Files[0].FileName);

            if (form.Files[0].FileName.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await form.Files[0].CopyToAsync(stream);
                }
            }
            if (Convert.ToString(form["Id"]) == string.Empty || Convert.ToString(form["Id"]) == "0")
            {
                return RedirectToAction("Create", new {FileName = Convert.ToString(form.Files[0].FileName) });
            }
            else
            {
                return RedirectToAction("Edit", new { FileName = Convert.ToString(form.Files[0].FileName), id = Convert.ToString(form["Id"]) });
            }
        }
    }
}