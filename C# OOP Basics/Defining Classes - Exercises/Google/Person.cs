using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public class Company
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        
    }
    public class Pokemon
    {
        public string Name { get; set; }
        public string  Type { get; set; }
        public Pokemon(string name,string type)
        {
            Name = name;
            Type = type;
        }
    }
    public class Parent
    {
        public string Name { get; set; }
        public string Birthday { get; set; }
        public Parent(string name,string birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
    public class Children
    {
        public string Name { get; set; }
        public string Birthday { get; set; }
        public Children(string name,string birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
    public class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        
    }

    public string Name { get; set; }
    public Company CompanyName { get; set; }
    public Car CarModel { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Children> Childrens { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Person(string name)
    {
        Name = name;
        CompanyName = new Company();
        CarModel = new Car();
        Parents = new List<Parent>();
        Childrens = new List<Children>();
        Pokemons = new List<Pokemon>();
    }
    
}
