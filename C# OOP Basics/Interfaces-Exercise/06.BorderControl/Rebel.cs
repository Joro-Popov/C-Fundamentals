using System;
using System.Collections.Generic;
using System.Text;

public class Rebel : Person
{
    private string group;
    
    public Rebel(string name, int age, string group)
        :base(name,age)
    {
        this.Group = group;
    }
    
    public string Group
    {
        get { return group; }
        private set { group = value; }
    }
    
    public override void BuyFood()
    {
        this.Food += 5;
    }
}
