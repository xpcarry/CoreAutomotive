using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceAPI
{
    public static class CarGenerator
    {
        public static string GenerateBrand(int val)
        {
            Dictionary<int, string> carBrand = new Dictionary<int, string>();
            carBrand.Add(0, "Saab");
            carBrand.Add(1, "BMW");
            carBrand.Add(2, "Hyundai");
            carBrand.Add(3, "Volkswagen");
            carBrand.Add(4, "Skoda");

            return carBrand[val];
        }

        public static string GenerateModel(string brand, int val)
        {
            Dictionary<int, string> carModel = new Dictionary<int, string>();
            switch (brand)
            {
                case "Saab":
                    {
                        carModel.Add(0, "900");
                        carModel.Add(1, "9-3");
                        carModel.Add(2, "9-5");
                        carModel.Add(3, "Aero-X");
                        carModel.Add(4, "9000");
                        carModel.Add(5, "9-X Air");
                        return carModel[val];
                    }
                case "BMW":
                    {
                        carModel.Add(0, "3");
                        carModel.Add(1, "5");
                        carModel.Add(2, "7");
                        carModel.Add(3, "M3");
                        carModel.Add(4, "Z");
                        carModel.Add(5, "F30");
                        return carModel[val];
                    }
                case "Hyundai":
                    {
                        carModel.Add(0, "i30");
                        carModel.Add(1, "i20");
                        carModel.Add(2, "Elantra");
                        carModel.Add(3, "Santa Fe");
                        carModel.Add(4, "Tuscon");
                        carModel.Add(5, "Accent");
                        return carModel[val];
                    }
                case "Volkswagen":
                    {
                        carModel.Add(0, "Golf");
                        carModel.Add(1, "Passat");
                        carModel.Add(2, "Polo");
                        carModel.Add(3, "Jetta");
                        carModel.Add(4, "Transporter");
                        carModel.Add(5, "Caddy");
                        return carModel[val];
                    }
                case "Skoda":
                    {
                        carModel.Add(0, "Fabia");
                        carModel.Add(1, "Octavia");
                        carModel.Add(2, "Superb");
                        carModel.Add(3, "Citigo");
                        carModel.Add(4, "Kodiaq");
                        carModel.Add(5, "Yeti");
                        return carModel[val];
                    }

                default:
                    break;
            }

            return null;
        }

        public static string GenerateFuelType(int val)
        {
            Dictionary<int, string> fuelType = new Dictionary<int, string>
            {
                {0, "Gasoline" },
                {1, "Diesel" },
                {2, "Natural gas" },
            };
            return fuelType[val];
        }
    }
}
