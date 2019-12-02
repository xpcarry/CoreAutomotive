using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.Models
{
    public class PowerkCarRepository : ICarRepository
    {

        private List<Car> Cars;

        public PowerkCarRepository()
        {
            if (Cars == null)

            {
                InitializeCars();
            }
        }

        private void InitializeCars()
        {
            //Cars = new List<Car>
            //{
            //    new Car { Id=1, Brand="Ford", Model="Mustang", ProductionYear = 2016, Mileage = "34 000 km", Engine = "4 900 cm3", FuelType= "benzyna", Power = "421 KM", Description="Mam do sprzedania Mustanga 5.0 GT V8 421KM. Kupiony w Polskim SALONIE FORDA w Opolu jako NOWY w kwietniu 2016", Price = 160000M, PictureUrl="/images/fordMustang.jpg", ThumbnailUrl="/images/fordMustang.jpg"},
            //    new Car { Id=2, Brand="Audi", Model="S5", ProductionYear = 2013, Mileage = "112 000 km", Engine = "3 000 cm3", FuelType= "benzyna", Power = "280 KM", Description="Do sprzedania Audi S5 z 2013 roku. Jestem właścicielem tego Caru od ponad dwóch lat.", Price = 115000M, PictureUrl="/images/audiS5.jpg", ThumbnailUrl="/images/audiS5.jpg"},
            //    new Car { Id=3, Brand="BMV", Model="X4", ProductionYear = 2017, Mileage = "4 300 km", Engine = "1 995 cm3", FuelType= "benzyna", Power = "190 KM", Description="BMV X4 20d xDrive. SaPowerhód krajowy. SaPowerhód serwisowany. Wystawiamy fakturę VAT 23%. SaPowerhód bezwypadkowy. I właściciel.", Price = 194000M, PictureUrl="/images/bmvx4.jpg", ThumbnailUrl="/images/bmvx4.jpg"},
            //    new Car { Id=4, Brand="Chevrolet", Model="Corvette", ProductionYear = 1972, Mileage = "28 000 km", Engine = "5 700 cm3", FuelType= "benzyna", Power = "300 KM", Description="Corvetta jest w świetnym stanie wizualnym i mechanicznym. Oczywiście jest ZAREJESTROWANA i ubezpieczona w PL.", Price = 90000M, PictureUrl="/images/chevroletCorvete.jpg", ThumbnailUrl="/images/chevroletCorvete.jpg"},
            //    new Car { Id=5, Brand="Nissan", Model="Skyline", ProductionYear = 1995, Mileage = "144 000 km", Engine = "2 500 cm3", FuelType= "benzyna", Power = "410 KM", Description="Na sprzedaż trafia moja perełka Nissan Skyline R33.Auto z Japonii sprowadzone do Szwecji, gdzie było przez wiele lat modyfikowane, uczestniczyło w zlotach, zdobywało nagrody, saPowerhód sponsorowany latami przez Sonax Sweden.", Price = 120000M, PictureUrl="/images/nissan.jpg", ThumbnailUrl="/images/nissan.jpg"},
            //    new Car { Id=6, Brand="Jaguar", Model="ZX", ProductionYear = 2006, Mileage = "78000 km", Engine = "5 000 cm3", FuelType= "benzyna", Power = "510 KM", Description="Przedstawiam Państwu wyjątkowe auto jakim jest Jaguar XKR, a zwłaszcza ten egzemplarz. Jaguar XKR to ikona światowej i brytyjskiem motoryzacji, a przede wszystkim kontynuator legendarnego już Jaguara E-typa, przez wielu uważany za najpiękniejsze auto w historii motoryzacji.", Price = 200000M, PictureUrl="/images/jaguar.jpg", ThumbnailUrl="/images/jaguar.jpg"}
            //};
        }

        public Car GetCarById(int CarId)
        {
            return Cars.FirstOrDefault(s => s.Id == CarId);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return Cars;
        }

        public void AddCar(Car Car)
        {
            throw new NotImplementedException();
        }

        public void EditCar(Car Car)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar(Car Car)
        {
            throw new NotImplementedException();
        }
    }
}
