﻿using System;

public class Product
{
    private string name;
    private decimal cost;

    public decimal Cost
    {
        get { return cost; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            cost = value;
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public Product(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}