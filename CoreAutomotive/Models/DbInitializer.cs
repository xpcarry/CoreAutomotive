using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace CoreAutomotive.Models
{
    public static class DbInitializer
    {

        public static void SeedData(UserManager<UserData> userManager, RoleManager<Role> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager, roleManager);
        }

        public static void SeedRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(new Role() {Name = "User" });
                roleManager.CreateAsync(new Role() {Name = "Admin"});
            }
        }


        public static void SeedUsers(UserManager<UserData> userManager, RoleManager<Role> roleManager)
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
                    UserName = "admin",
                };
                

                IdentityResult result = userManager.CreateAsync(user, password: "Admin1!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin");
                }

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
                    UserName = "test",
                };

                IdentityResult result2 = userManager.CreateAsync(user2, password: "Test1!").Result;
                if (result2.Succeeded)
                {
                    userManager.AddToRoleAsync(user2, "User");
                }

            }
        }


        public static void Seed(AppDbContext context)
        {

            if (!context.Cars.Any())
            {
                var cars = new List<Car>
                {

                new Car { 
                    Id=1,
                    UserId = 1,
                    UserName="admin",
                    DateAdded = DateTime.Now,
                    Brand="Ford",
                    Model="Mustang",
                    ProductionYear = 2016,
                    Mileage = "34 000 km",
                    Engine = "4 900 cm3",
                    FuelType= "benzyna",
                    Power = "421 KM",
                    Description="Mam do sprzedania Mustanga 5.0 GT V8 421KM. Kupiony w Polskim SALONIE FORDA w Opolu jako NOWY w kwietniu 2016",
                    Price = 160000M,
                    Pictures = new List<Picture>{ new Picture { PictureUrl = "/images/fordMustang.jpg", ThumbnailUrl = "/images/fordMustang.jpg", UserId=1} } },
                new Car { 
                    Id=2,
                    UserId = 1, 
                    UserName="admin",
                    DateAdded = DateTime.Now,
                    Brand="Audi",
                    Model="S5",
                    ProductionYear = 2013,
                    Mileage = "112 000 km",
                    Engine = "3 000 cm3",
                    FuelType= "benzyna",
                    Power = "280 KM",
                    Description="Do sprzedania Audi S5 z 2013 roku. Jestem właścicielem tego samochodu od ponad dwóch lat.",
                    Price = 115000M,
                    Pictures = new List<Picture>{ new Picture { PictureUrl = "/images/audiS5.jpg", ThumbnailUrl = "/images/audiS5.jpg", UserId = 1 } } },
                new Car { 
                    Id=3,
                    UserId = 2,
                    UserName="test",
                    DateAdded = DateTime.Now,
                    Brand="BMV",
                    Model="X4",
                    ProductionYear = 2017,
                    Mileage = "4 300 km",
                    Engine = "1 995 cm3",
                    FuelType= "benzyna",
                    Power = "190 KM",
                    Description="BMV X4 20d xDrive. Samochod krajowy. Samochod serwisowany. Wystawiamy fakturę VAT 23%. Samochod bezwypadkowy. I właściciel.",
                    Price = 194000M,
                    Pictures = new List<Picture>{ new Picture { PictureUrl = "/images/bmvx4.jpg", ThumbnailUrl = "/images/bmvx4.jpg", UserId=1 } } },
                new Car { 
                    Id=4,
                    UserId = 2, 
                    UserName="test", 
                    DateAdded = DateTime.Now, 
                    Brand="Chevrolet", 
                    Model="Corvette", 
                    ProductionYear = 1972, 
                    Mileage = "28 000 km", 
                    Engine = "5 700 cm3", 
                    FuelType= "benzyna", 
                    Power = "300 KM", 
                    Description="Corvetta jest w świetnym stanie wizualnym i mechanicznym. Oczywiście jest ZAREJESTROWANA i ubezpieczona w PL.", 
                    Price = 90000M, 
                    Pictures = new List<Picture>{ new Picture { PictureUrl = "/images/chevroletCorvete.jpg", ThumbnailUrl = "/images/chevroletCorvete.jpg", UserId=1 } } },
                new Car { 
                    Id=5, 
                    UserId = 2,
                    UserName="test",
                    DateAdded = DateTime.Now,
                    Brand="Nissan", 
                    Model="Skyline", 
                    ProductionYear = 1995,
                    Mileage = "144 000 km", 
                    Engine = "2 500 cm3", 
                    FuelType= "benzyna", 
                    Power = "410 KM", 
                    Description="Na sprzedaż trafia moja perełka Nissan Skyline R33.Auto z Japonii sprowadzone do Szwecji, gdzie było przez wiele lat modyfikowane, uczestniczyło w zlotach, zdobywało nagrody, Samochod sponsorowany latami przez Sonax Sweden.", 
                    Price = 120000M, 
                    Pictures = new List<Picture>{ new Picture { PictureUrl = "/images/nissan.jpg", ThumbnailUrl = "/images/nissan.jpg", UserId=2 } } },

                };
                cars.ForEach(s => context.Cars.Add(s));
                context.SaveChanges();

                //2nd soulution context.AddRange( new Car..)
            }






        }


    }
}

