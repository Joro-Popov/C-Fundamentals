using System;
using System.Collections.Generic;
using System.Linq;

public class Dough
{
    private const double MinWeight = 1;
    private const double MaxWeight = 200;

    private string type;
    private string bakingTechnique;
    private double weight;

    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        private set
        {
            if (value.ToLower() == "crispy" ||
                value.ToLower() == "chewy" ||
                value.ToLower() == "homemade")
            {
                bakingTechnique = value;
            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }

    public string Type
    {
        get { return type; }
        private set
        {
            if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
            {
                type = value;
            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }

    public Dough(string input)
    {
        List<string> info = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Type = info[1];
        BakingTechnique = info[2];
        Weight = double.Parse(info[3]);
    }

    public double CalculateCalories(Dough dough)
    {
        double typeModifier = GetTypeModifier(dough.Type);
        double techniqueModifier = GetTechniqueModifier(dough.bakingTechnique);

        double totalCalories = (2 * weight) * typeModifier * techniqueModifier;
        return totalCalories;
    }

    private static double GetTypeModifier(string modifier)
    {
        double mod = 0;
        switch (modifier.ToLower())
        {
            case "white": mod = 1.5; break;
            case "wholegrain": mod = 1.0; break;
        }
        return mod;
    }

    private static double GetTechniqueModifier(string technique)
    {
        double mod = 0;
        switch (technique.ToLower())
        {
            case "crispy": mod = 0.9; break;
            case "chewy": mod = 1.1; break;
            case "homemade": mod = 1.0; break;
        }
        return mod;
    }
}