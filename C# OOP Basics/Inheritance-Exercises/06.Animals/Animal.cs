using System;

public class Animal
{
    private string name;
    private int age;
    private string gender;
    private string sound;

    private const string Error = "Invalid input!";

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    protected string Sound
    {
        get { return sound; }
        set { sound = value; }
    }

    protected virtual string Gender
    {
        get { return gender; }
        set
        {
            if (IsNotValid(value))
            {
                throw new ArgumentException(Error);
            }
            gender = value;
        }
    }

    protected int Age
    {
        get { return age; }
        set
        {
            if (IsNotValid(value.ToString()) || value < 0)
            {
                throw new ArgumentException(Error);
            }
            age = value;
        }
    }

    protected string Name
    {
        get { return name; }
        set
        {
            if (IsNotValid(value))
            {
                throw new ArgumentException(Error);
            }
            name = value;
        }
    }

    private bool IsNotValid(string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        {
            return true;
        }
        return false;
    }

    public string ProduceSound()
    {
        return Sound;
    }

    public override string ToString()
    {
        return $"{this.GetType()}\r\n" +
               $"{this.Name} {this.Age} {this.Gender}\r\n" +
               $"{this.ProduceSound()}";
    }
}