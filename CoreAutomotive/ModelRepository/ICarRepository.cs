using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.Models
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int CarId);

        void AddCar(Car Car);
        void EditCar(Car Car);
        void DeleteCar(Car Car);


    }
}
