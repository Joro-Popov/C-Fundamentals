﻿using System;

public class Startup
{
    private static void Main()
    {
        Animal cat = new Cat("Pesho", "Whiskas");
        Animal dog = new Dog("Gosho", "Meat");

        Console.WriteLine(cat.ExplainSelf());
        Console.WriteLine(dog.ExplainSelf());
    }
}