using System;
using System.Collections.Generic;
using System.Text;

public class Pokemon
{
    public string Name { get; set; }
    public string Element { get; set; }
    public long Health { get; set; }

    public Pokemon(string name,string element,long health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }
}
