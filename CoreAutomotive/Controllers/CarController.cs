using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAutomotive.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAutomotive.Controllers
{
    public class CarController : Controller
    {
        private readonly ISamochodRepository _samochodRepository;

        public CarController(ISamochodRepository samochodRepository)
        {
            _samochodRepository = samochodRepository;
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
    }
}