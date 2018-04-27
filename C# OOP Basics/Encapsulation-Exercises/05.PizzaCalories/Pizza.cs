using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int MaxValueLenght = 15;
    private const int MinValueToppings = 0;
    private const int MaxValueToppings = 10;

    private string name;
    private List<Topping> toppings;
    private Dough dough;

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public List<Topping> Toppings
    {
        get { return toppings; }
        private set
        {
            if (value.Count < MinValueToppings || value.Count > MaxValueToppings)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings = value;
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value) ||
                value.Length > MaxValueLenght)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    public Pizza(string input)
    {
        List<string> tokens = input.Split().ToList();
        Name = tokens[1];
        Toppings = new List<Topping>();
    }

    public override string ToString()
    {
        double calories = dough.CalculateCalories(dough) +
                            toppings.Sum(t => t.CalculateCalories(t));

        return $"{Name} - {calories:f2} Calories.";
    }

    public void AddTopping(Topping topping, List<Topping> toppings)
    {
        if (toppings.Count > MaxValueToppings)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        Toppings.Add(topping);
    }
}