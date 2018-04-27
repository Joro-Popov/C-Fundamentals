using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        var persons = new Dictionary<string, Person>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            List<string> info = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string name = info[0];
            Person person = new Person(name);
            if (!persons.ContainsKey(name))
            {
                persons[name] = new Person(name);
            }
            if (info[1] == "company")
            {
                string companyName = info[2];
                string department = info[3];
                decimal salary = decimal.Parse(info[4]);
                persons[name].CompanyName.Name = companyName;
                persons[name].CompanyName.Department = department;
                persons[name].CompanyName.Salary = salary;
            }
            else if (info[1] == "pokemon")
            {
                string pokemonName = info[2];
                string pokemonType = info[3];
                Person.Pokemon pokemon = new Person.Pokemon(pokemonName,pokemonType);
                persons[name].Pokemons.Add(pokemon);
            }
            else if (info[1] == "parents")
            {
                string parentName = info[2];
                string birthday = info[3];
                Person.Parent parent = new Person.Parent(parentName, birthday);
                persons[name].Parents.Add(parent);
            }
            else if (info[1] == "children")
            {
                string childrenName = info[2];
                string birthday = info[3];
                Person.Children child = new Person.Children(childrenName,birthday);
                persons[name].Childrens.Add(child);
            }
            else if (info[1] == "car")
            {
                string model = info[2];
                int speed = int.Parse(info[3]);
                persons[name].CarModel.Model = model;
                persons[name].CarModel.Speed = speed;
            }
        }

        Person currentPerson = persons[Console.ReadLine()];
        Person.Company currentCompany = currentPerson.CompanyName;
        Person.Car currentCar = currentPerson.CarModel;
        List<Person.Pokemon> pokemons = currentPerson.Pokemons;
        List<Person.Parent> parents = currentPerson.Parents;
        List<Person.Children> childrens = currentPerson.Childrens;

        Console.WriteLine(currentPerson.Name);
        Console.WriteLine("Company:");
        if (currentCompany.Salary != 0)
        {
            Console.WriteLine($"{currentCompany.Name} {currentCompany.Department} {currentCompany.Salary:f2}");
        }
        Console.WriteLine("Car:");
        if (currentCar.Speed != 0)
        {
            Console.WriteLine($"{currentCar.Model} {currentCar.Speed}");
        }
        Console.WriteLine("Pokemon:");
        foreach (var pokemon in pokemons)
        {
            Console.WriteLine($"{pokemon.Name} {pokemon.Type}");
        }
        Console.WriteLine("Parents:");
        foreach (var parent in parents)
        {
            Console.WriteLine($"{parent.Name} {parent.Birthday}");
        }
        Console.WriteLine($"Children:");
        foreach (var child in childrens)
        {
            Console.WriteLine($"{child.Name} {child.Birthday}");
        }
    }
}
