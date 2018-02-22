using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _04._Population_Counter
{
    public class Country
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }

        public Country(string name)
        {
            Name = name;
            Cities = new List<City>();
        }
    }
    public class City
    {
        public string Name { get; set; }
        public long Population { get; set; }

        public City(string name, long population)
        {
            Name = name;
            Population = population;
        }
    }
    public class Startup
    {
        public static void AddCity(List<Country> Countries, string countryName, City currentCity)
        {
            foreach (var country in Countries)
            {
                if (country.Name == countryName)
                {
                    country.Cities.Add(currentCity);
                    break;
                }
            }
        }
        public static void Main()
        {
            string input;
            List<Country> Countries = new List<Country>();

            while ((input = Console.ReadLine()) != "report")
            {
                List<string> arguments = input.Split('|').ToList();
                string cityName = arguments[0];
                string countryName = arguments[1];
                long cityPopulation = long.Parse(arguments[2]);

                City currentCity = new City(cityName, cityPopulation);
                Country currentCountry = new Country(countryName);

                if (!Countries.Any(c => c.Name == countryName))
                {
                    Countries.Add(currentCountry);
                }
                AddCity(Countries, countryName, currentCity);
            }

            Countries = Countries
                .OrderByDescending(w => w.Cities.Sum(c => c.Population))
                .ToList();

            foreach (var country in Countries)
            {
                string countryName = country.Name;
                BigInteger totalPopulation = country.Cities.Sum(c => c.Population);
                List<City> cities = country.Cities;
                
                Console.WriteLine($"{countryName} (total population: {totalPopulation})");

                foreach (var city in cities.OrderByDescending(c => c.Population))
                {
                    Console.WriteLine($"=>{city.Name}: {city.Population}");
                }
            }
        }
        
    }
}
