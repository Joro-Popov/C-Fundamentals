using System;
using System.Collections.Generic;
using System.Text;

public abstract class Person : IPerson, IBuyer
{
    private string name;
    private int age;
    private int food;

    public Person(string name, int age )
    {
        this.Name = name;
        this.Age = age;
        this.Food = 0;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        private set { this.age = value; }
    }

    public int Food
    {
        get { return this.food; }
        protected set { this.food = value; }
    }

    public virtual void BuyFood()
    {

    }
}
