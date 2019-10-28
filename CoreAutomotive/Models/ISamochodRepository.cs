using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.Models
{
    public interface ISamochodRepository
    {
        IEnumerable<Samochod> PobierzWszystkieSamochody();
        Samochod PobierzSamochodOId(int samochodId);

        void AddCar(Samochod samochod);
        void EditCar(Samochod samochod);
        void DeleteCar(Samochod samochod);


    }
}
