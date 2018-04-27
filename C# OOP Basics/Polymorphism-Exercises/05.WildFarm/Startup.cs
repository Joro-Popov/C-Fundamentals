using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    private static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            List<string> animalInfo = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> foodInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Animal currentAnimal = GetAnimal(animalInfo);
            Food currentFood = GetFood(foodInfo);

            Console.WriteLine(currentAnimal.ProduceSound());
            try
            {
                currentAnimal.Feed(currentFood);
                animals.Add(currentAnimal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                animals.Add(currentAnimal);
            }
        }
        if (animals.Count > 0)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }

    private static Animal GetAnimal(List<string> animalInfo)
    {
        string type = animalInfo[0];

        switch (type)
        {
            case "Cat":
                return new Cat(animalInfo[1],
                               double.Parse(animalInfo[2]),
                               animalInfo[3],
                               animalInfo[4]);

            case "Dog":
                return new Dog(animalInfo[1],
                               double.Parse(animalInfo[2]),
                               animalInfo[3]);

            case "Hen":
                return new Hen(animalInfo[1],
                               double.Parse(animalInfo[2]),
                               double.Parse(animalInfo[3]));

            case "Mouse":
                return new Mouse(animalInfo[1],
                                 double.Parse(animalInfo[2]),
                                 animalInfo[3]);

            case "Owl":
                return new Owl(animalInfo[1],
                               double.Parse(animalInfo[2]),
                               double.Parse(animalInfo[3]));

            case "Tiger":
                return new Tiger(animalInfo[1],
                                 double.Parse(animalInfo[2]),
                                 animalInfo[3],
                                 animalInfo[4]);

            default: return null;
        }
    }

    private static Food GetFood(List<string> foodInfo)
    {
        switch (foodInfo[0])
        {
            case "Fruit": return new Fruit(int.Parse(foodInfo[1]));
            case "Meat": return new Meat(int.Parse(foodInfo[1]));
            case "Seeds": return new Seeds(int.Parse(foodInfo[1]));
            case "Vegetable": return new Vegetable(int.Parse(foodInfo[1]));
            default: return null;
        }
    }
}