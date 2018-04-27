using System;
using System.Collections.Generic;
using System.Text;

public class Pet : IComparable<Pet>
{
    public Pet(string name, int age, string kind)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = kind;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Kind { get; private set; }

    public int CompareTo(Pet other)
    {
        if (this.Name.CompareTo(other.Name) == 0)
        {
            if (this.Age.CompareTo(other.Age) == 0)
            {
                return this.Kind.CompareTo(other.Kind);
            }

            return this.Age.CompareTo(other.Age);
        }

        return this.Name.CompareTo(other.Name);
    }
    
    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }
}
