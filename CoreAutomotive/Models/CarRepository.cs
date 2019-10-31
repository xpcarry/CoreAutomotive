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

        public Samochod PobierzSamochodOId(int samochodId)
        {
            return _appDbContext.Samochody.FirstOrDefault(s => s.Id == samochodId);
                
        }

        public IEnumerable<Samochod> PobierzWszystkieSamochody()
        {
            return _appDbContext.Samochody;
        }

        public void AddCar(Samochod samochod)
        {
            _appDbContext.Samochody.Add(samochod);
            _appDbContext.SaveChanges();
        }

        public void DeleteCar(Samochod samochod)
        {
            _appDbContext.Samochody.Remove(samochod);
            _appDbContext.SaveChanges();
        }

        public void EditCar(Samochod samochod)
        {
            _appDbContext.Samochody.Update(samochod);
            _appDbContext.SaveChanges();
        }
    }
}
