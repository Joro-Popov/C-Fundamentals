using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IPerson,IResident
{
    private string name;
    private int age;
    private string country;

    public Citizen(string name,string country,int age)
    {
        this.Name = name;
        this.Country = country;
        this.Age = age;
    }

    public string Country
    {
        get { return country; }
        private set { country = value; }
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.Name}";
    }

    string IPerson.GetName()
    {
        return this.Name;
    }
}
