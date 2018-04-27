using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }
    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            firstName = value;
        }
    }
    public string LastName
    {
        get { return lastName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            lastName = value;
        }
    }
    public int Age
    {
        get { return age; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            age = value;
        }
    }
    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value < 460.0m)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
            salary = value;
        }
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} gets {salary:f2} leva.";
    }
    public void IncreaseSalary(decimal percentage)
    {
        if (this.age < 30)
        {
            this.salary += salary * percentage / 200;
        }
        else
        {
            this.salary += salary * percentage / 100;
        }
    }
}
