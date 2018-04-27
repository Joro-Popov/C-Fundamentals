using System;
using System.Collections.Generic;

internal abstract class AnimalFactory
{
    public static Animal CreateAnimal(string type, List<string> info)
    {
        switch (type)
        {
            case "Cat": return new Cat(info[0], int.Parse(info[1]), info[2]);
            case "Dog": return new Dog(info[0], int.Parse(info[1]), info[2]);
            case "Frog": return new Frog(info[0], int.Parse(info[1]), info[2]);
            case "Tomcat": return new Tomcat(info[0], int.Parse(info[1]), info[2]);
            case "Kitten": return new Kitten(info[0], int.Parse(info[1]), info[2]);
            default: throw new ArgumentException("Invalid input!");
        }
    }
}