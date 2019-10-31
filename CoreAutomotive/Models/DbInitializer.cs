using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace CoreAutomotive.Models
{
    public static class DbInitializer
    {

        public static void SeedData(UserManager<UserData> userManager)
        {
            SeedUsers(userManager);
        }


        public static void SeedUsers(UserManager<UserData> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user =
                new UserData
                {
                    Id = 1,
                    Name = "Admin",
                    Surname = "Admin",
                    Email = "admin@coreautomotive.com",
                    City = "Warsaw",
                    DateJoined = DateTime.Now,
                    PhoneNumber = "1234",
                    UserName = "admin@coreautomotive.com",
                };
                var result = userManager.CreateAsync(user, password: "Admin1!");

                var user2 =
                new UserData
                {
                    Id = 2,
                    Name = "Test",
                    Surname = "Test",
                    Email = "test@coreautomotive.com",
                    City = "Warsaw",
                    DateJoined = DateTime.Now,
                    PhoneNumber = "1234",
                    UserName = "test@coreautomotive.com",
                };

                 IdentityResult result2 = userManager.CreateAsync(user2, password: "Test1!").Result;

            }
        }


        public static void Seed(AppDbContext context)
        {

            if (!context.Samochody.Any())
            {
                var samochody = new List<Samochod>
                {

                new Samochod { Id=1, UserId = 1, DateAdded = DateTime.Now, Marka="Ford", Model="Mustang", RokProdukcji = 2016, Przebieg = "34 000 km", Pojemnosc = "4 900 cm3", RodzajPaliwa= "benzyna", Moc = "421 KM", Opis="Mam do sprzedania Mustanga 5.0 GT V8 421KM. Kupiony w Polskim SALONIE FORDA w Opolu jako NOWY w kwietniu 2016", Cena = 160000M, ZdjecieUrl="/images/fordMustang.jpg", MiniaturkaUrl="/images/fordMustang.jpg"},
                new Samochod { Id=2, UserId = 1, DateAdded = DateTime.Now, Marka="Audi", Model="S5", RokProdukcji = 2013, Przebieg = "112 000 km", Pojemnosc = "3 000 cm3", RodzajPaliwa= "benzyna", Moc = "280 KM", Opis="Do sprzedania Audi S5 z 2013 roku. Jestem właścicielem tego samochodu od ponad dwóch lat.", Cena = 115000M, ZdjecieUrl="/images/audiS5.jpg", MiniaturkaUrl="/images/audiS5.jpg"},
                new Samochod { Id=3, UserId = 1, DateAdded = DateTime.Now, Marka="BMV", Model="X4", RokProdukcji = 2017, Przebieg = "4 300 km", Pojemnosc = "1 995 cm3", RodzajPaliwa= "benzyna", Moc = "190 KM", Opis="BMV X4 20d xDrive. Samochód krajowy. Samochód serwisowany. Wystawiamy fakturę VAT 23%. Samochód bezwypadkowy. I właściciel.", Cena = 194000M, ZdjecieUrl="/images/bmvx4.jpg", MiniaturkaUrl="/images/bmvx4.jpg"},
                new Samochod { Id=4, UserId = 1, DateAdded = DateTime.Now, Marka="Chevrolet", Model="Corvette", RokProdukcji = 1972, Przebieg = "28 000 km", Pojemnosc = "5 700 cm3", RodzajPaliwa= "benzyna", Moc = "300 KM", Opis="Corvetta jest w świetnym stanie wizualnym i mechanicznym. Oczywiście jest ZAREJESTROWANA i ubezpieczona w PL.", Cena = 90000M, ZdjecieUrl="/images/chevroletCorvete.jpg", MiniaturkaUrl="/images/chevroletCorvete.jpg"},
                new Samochod { Id=5, UserId = 2, DateAdded = DateTime.Now, Marka="Nissan", Model="Skyline", RokProdukcji = 1995, Przebieg = "144 000 km", Pojemnosc = "2 500 cm3", RodzajPaliwa= "benzyna", Moc = "410 KM", Opis="Na sprzedaż trafia moja perełka Nissan Skyline R33.Auto z Japonii sprowadzone do Szwecji, gdzie było przez wiele lat modyfikowane, uczestniczyło w zlotach, zdobywało nagrody, samochód sponsorowany latami przez Sonax Sweden.", Cena = 120000M, ZdjecieUrl="/images/nissan.jpg", MiniaturkaUrl="/images/nissan.jpg"},

                };
                samochody.ForEach(s => context.Samochody.Add(s));
                context.SaveChanges();

                //2nd soulution context.AddRange( new Samochod..)
            }




        }


    }
}

