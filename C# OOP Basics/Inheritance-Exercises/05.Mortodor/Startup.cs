using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    private static void Main()
    {
        List<string> foodsInput = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        List<Food> foods = new List<Food>();
        foreach (var food in foodsInput)
        {
            Food current = FoodFactory.GetFood(food);
            foods.Add(current);
        }

        int gandalfPoints = MoodFactory.Happiness(foods);
        Mood mood = MoodFactory.GetMood(gandalfPoints);

        Console.WriteLine(gandalfPoints);
        Console.WriteLine(mood);
    }
}