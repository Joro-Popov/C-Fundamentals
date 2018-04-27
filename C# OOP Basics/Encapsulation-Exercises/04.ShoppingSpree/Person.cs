using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        products = new List<Product>();
    }

    public List<Product> Products
    {
        get { return products; }
        private set { products = value; }
    }

    public decimal Money
    {
        get { return money; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
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

    public void BuyProduct(Product product)
    {
        this.money -= product.Cost;
        this.products.Add(product);
    }

    public override string ToString()
    {
        if (products.Count == 0)
        {
            return $"{Name} - Nothing bought";
        }
        else
        {
            return $"{Name} - {string.Join(", ", products)}";
        }
    }
}