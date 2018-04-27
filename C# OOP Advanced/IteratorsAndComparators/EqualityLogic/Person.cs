using System;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }

    public int CompareTo(Person other)
    {
        if (this.Name.CompareTo(other.Name) == 0)
        {
            return this.Age - other.Age;
        }

        return this.Name.CompareTo(other.Name);
    }

    public override bool Equals(object obj)
    {
        Person other = obj as Person;

        if (this.Name.Equals(other.Name))
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        int prime = 83;
        int result = 1;

        unchecked
        {
            result *= prime + this.Name.GetHashCode();
            result *= prime + this.Age.GetHashCode();
        }

        return result;
    }
}
