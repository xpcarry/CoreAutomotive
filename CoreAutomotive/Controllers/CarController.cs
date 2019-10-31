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

        private readonly ICarRepository _samochodRepository;
        private IWebHostEnvironment _env;

        public CarController(ICarRepository samochodRepository, IWebHostEnvironment env)
        {
            _samochodRepository = samochodRepository;
            _env = env;
        }

        public IActionResult Index()
        {
            var samochody = _samochodRepository.PobierzWszystkieSamochody();
            return View(samochody);
        }

        public IActionResult Details(int id)
        {
            var samochod = _samochodRepository.PobierzSamochodOId(id);
            if (samochod == null)
            {
                return NotFound();
            }
            return View(samochod);
        }

        public IActionResult Create(string FileName)
        {
            if (!string.IsNullOrEmpty(FileName))
                ViewBag.ImgPath = "/Images/" + FileName;
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                _samochodRepository.AddCar(samochod);
                return RedirectToAction(nameof(Index));
            }

            return View(samochod);
        }

        public IActionResult Edit(int id, string FileName)
        {
            var samochod = _samochodRepository.PobierzSamochodOId(id);

            if (samochod==null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(FileName))
                ViewBag.ImgPath = "/Images/" + FileName;
            else ViewBag.ImgPath = samochod.ZdjecieUrl;

            return View(samochod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                _samochodRepository.EditCar(samochod);
                return RedirectToAction(nameof(Index));
            }
            return View(samochod);
        }


        public IActionResult Delete(int id)
        {
            var samochod = _samochodRepository.PobierzSamochodOId(id);

            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }


        //Doweryfikacji
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Samochod samochod, string ZdjecieUrl)
        {
            if (ModelState.IsValid)
            {
                _samochodRepository.DeleteCar(samochod);

                //delete picture
                if (ZdjecieUrl != null)
                {
                    var webRoot = _env.WebRootPath;
                    var filePath = Path.Combine(webRoot.ToString() + ZdjecieUrl);
                    System.IO.File.Delete(filePath);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(samochod);
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