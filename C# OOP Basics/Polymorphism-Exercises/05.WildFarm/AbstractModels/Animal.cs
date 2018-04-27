using System;
using System.Collections.Generic;

public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;
    private List<string> eatableFoods;

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
        this.EatableFoods = new List<string>();
    }

    public List<string> EatableFoods
    {
        get { return eatableFoods; }
        private set { eatableFoods = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        private set { foodEaten = value; }
    }

    public double Weight
    {
        get { return weight; }
        protected set { weight = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public abstract string ProduceSound();

    public virtual void Feed(Food food)
    {
        if (this.EatableFoods.Contains(food.GetType().Name))
        {
            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}