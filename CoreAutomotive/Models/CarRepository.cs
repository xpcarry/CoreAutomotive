using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreAutomotive.Models
{
    public class CarRepository : ICarRepository
    {

        private readonly AppDbContext _appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Car GetCarById(int CarId)
        {
            return _appDbContext.Cars.FirstOrDefault(s => s.Id == CarId);
                
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _appDbContext.Cars;
        }

        public void AddCar(Car Car)
        {
            _appDbContext.Cars.Add(Car);
            _appDbContext.SaveChanges();
        }

        public void DeleteCar(Car Car)
        {
            _appDbContext.Cars.Remove(Car);
            _appDbContext.SaveChanges();
        }

        public void EditCar(Car Car)
        {
            _appDbContext.Cars.Update(Car);
            _appDbContext.SaveChanges();
        }
    }
}
