using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age,decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }
    public string FirstName
    {
        get { return firstName; }
    }

    public string LastName
    {
        get { return lastName; }
    }

    public int Age
    {
        get { return age; }
    }
    public decimal Salary
    {
        get { return salary; }
    }
    public override string ToString()
    {
        return $"{firstName} {lastName} receives {salary:f2} leva.";
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
