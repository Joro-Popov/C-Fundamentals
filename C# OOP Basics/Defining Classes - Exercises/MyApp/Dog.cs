using System;
using System.Collections.Generic;
using System.Text;

public class Dog
{
    public string Name { get; set; }
    public Dog()
    {
        Name = "n/a";
    }
    public Dog(string name):this()
    {
        Name = name;
    }
    public void Bark()
    {
        Console.WriteLine($"{Name} said: Wow-wow!");
    }
}
