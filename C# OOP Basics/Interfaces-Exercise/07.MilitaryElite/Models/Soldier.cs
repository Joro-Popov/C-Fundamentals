using System;
using System.Collections.Generic;
using System.Text;

public abstract class Soldier : ISoldier
{
    private string id;
    private string firstName;
    private string lastName;
    private double salary;

    public Soldier(string id, string firstName, string lastName)
    {
        this.ID = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }
        
    public Soldier(string id, string firstName, string lastName, double salary)
        :this(id,firstName,lastName)
    {
        this.Salary = salary;
    }

    public string ID
    {
        get { return this.id; }
        protected set { this.id = value; }
    }

    public string FirstName
    {
        get { return this.firstName; }
        protected set { this.firstName = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
        protected set { this.lastName = value; }
    }

    public double Salary
    {
        get { return this.salary; }
        protected set { this.salary = value; }
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:f2}";
    }
}
