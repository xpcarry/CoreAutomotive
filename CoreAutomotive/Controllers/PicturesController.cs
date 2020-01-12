using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreAutomotive.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreAutomotive.Controllers
{
    public class PicturesController : Controller
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<UserData> _userManager;

        public PicturesController(IPictureRepository pictureRepository, IWebHostEnvironment env, UserManager<UserData> userManager)
        {
            _pictureRepository = pictureRepository;
            _env = env;
            _userManager = userManager;
        }

        public IActionResult AddPictures(string carId)
        {
            ViewBag.Id = carId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddPictures(List<IFormFile> files, string carId)
        {
            var webRoot = _env.WebRootPath;
            var filePaths = new List<string>();
            var pictures = new List<Picture>();
            long size = files.Sum(f => f.Length);

            if (files == null || files.Count == 0)
                return Content("file not selected");


            foreach (var formFile in files)
            {
                var filePath = Path.Combine(webRoot.ToString() + "//images//" + formFile.FileName);
                var imgPath = "/images/" + formFile.FileName;

                var user = await _userManager.GetUserAsync(HttpContext.User);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                var picture = new Picture
                {
                    PictureUrl = imgPath,
                    ThumbnailUrl = imgPath,
                    UserId = user.Id,
                    CarId = Convert.ToInt32(carId)
                };

                pictures.Add(picture);
            }

            _pictureRepository.AddPictures(pictures);

            return RedirectToAction("Details", "Home", new {id = Convert.ToInt32(carId) });

        }
    }
}