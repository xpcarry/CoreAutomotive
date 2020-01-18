using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CarServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        // GET: api/Car
        [HttpGet]
        public IActionResult Get()
        {
            var car = new Car();
            var rng = new Random();

            car.Brand = CarGenerator.GenerateBrand(rng.Next(0, 5));
            car.Model = CarGenerator.GenerateModel(car.Brand, rng.Next(0, 6));
            car.ProductionYear = rng.Next(1990, 2020);
            car.Mileage = rng.Next(0, 300000).ToString();
            car.FuelType = CarGenerator.GenerateFuelType(rng.Next(0, 3));
            car.Engine = rng.Next(1, 3).ToString() + "." + rng.Next(0, 10).ToString();
            car.Power = rng.Next(90, 300).ToString();
            car.Price = rng.Next(10000, 200000);
            car.Description = "Auto bez żadnej rdzy !!!  Silnik suchy bez wycieków , sprzęgło ) i skrzynia biegów pracują precyzyjnie bez zarzutów . Auto bardzoczyste i zadbane. . .Auto gotowe do eksploatacji bez wkładu finansowego UWAGA !!!!!!!!!!!!!! AUTO GOTOWE DO REJESTRACJI !!! UWAGA !!!!";


            return Ok(car);
        }

    }
}
