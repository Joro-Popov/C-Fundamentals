using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Position { get; set; }
    public string  Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    
    private Employee()
    {
        this.Email = "n/a";
        this.Age = -1;
    }
    public Employee(List<string>tokens):this()
    {
        this.Name = tokens[0];
        this.Salary = decimal.Parse(tokens[1]);
        this.Position = tokens[2];
        this.Department = tokens[3];

        if (tokens.Count == 5)
        {
            try
            {
                this.Age = int.Parse(tokens[4]);
            }
            catch (Exception)
            {
                this.Email = tokens[4];
            }
        }
        else if (tokens.Count == 6)
        {
            this.Email = tokens[4];
            this.Age = int.Parse(tokens[5]);
        }
    }
    public override string ToString()
    {
        return $"{this.Name} {this.Salary:f2} {this.Email} {this.Age}";
    }
}
