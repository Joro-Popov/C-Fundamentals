using System;
using System.Collections.Generic;
using System.Text;

public class Cat
{
    public string Breed { get; set; }
    public string Name { get; set; }
    public string Spec { get; set; }

    public Cat(string breed,string name,string spec)
    {
        Breed = breed;
        Name = name;
        Spec = spec;
    }
}
