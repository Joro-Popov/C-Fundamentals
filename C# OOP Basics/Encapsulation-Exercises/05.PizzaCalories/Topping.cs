using System;
using System.Collections.Generic;
using System.Linq;

public class Topping
{
    private const double MinWeight = 1;
    private const double MaxWeight = 50;

    private string type;
    private double weight;

    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public string Type
    {
        get { return type; }
        private set
        {
            if (value.ToLower() == "meat" || value.ToLower() == "veggies" ||
                value.ToLower() == "cheese" || value.ToLower() == "sauce")
            {
                type = value;
            }
            else
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }
    }

    public Topping(string input)
    {
        List<string> info = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Type = info[1];
        Weight = double.Parse(info[2]);
    }

    public double CalculateCalories(Topping topping)
    {
        double modifier = GetModifier(topping.Type);
        return (2 * topping.weight) * modifier;
    }

    private static double GetModifier(string modifier)
    {
        double mod = 0;
        switch (modifier.ToLower())
        {
            case "meat": mod = 1.2; break;
            case "veggies": mod = 0.8; break;
            case "cheese": mod = 1.1; break;
            case "sauce": mod = 0.9; break;
        }
        return mod;
    }
}