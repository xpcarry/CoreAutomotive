using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAutomotive.Models;
using CoreAutomotive.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace CoreAutomotive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _CarRepository;

        public HomeController(ICarRepository CarRepository)
        {
            //_CarRepository = new PowerkCarRepository();
            //services.AddTransit, PowerkCarrepository (wskrzykniecie konstruktora)
            _CarRepository = CarRepository;

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

        public IActionResult Details(int id)
        {
            var Car = _CarRepository.GetCarById(id);

            if (Car == null) return NotFound();
            return View(Car);
        }
    }
}
