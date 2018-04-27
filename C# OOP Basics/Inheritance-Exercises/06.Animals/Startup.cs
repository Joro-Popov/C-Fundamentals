using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    private static void Main()
    {
        string command;
        List<Animal> animals = new List<Animal>();

        while ((command = Console.ReadLine()) != "Beast!")
        {
            string animalType = command;
            List<string> info = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            try
            {
                Animal animal = AnimalFactory.CreateAnimal(animalType, info);
                animals.Add(animal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}