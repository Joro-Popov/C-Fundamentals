using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHours;

    public Worker(string firstName, string lastName, decimal salary, decimal hours)
        : base(firstName, lastName)
    {
        this.WeekSalary = salary;
        this.WorkHours = hours;
    }

    public decimal WorkHours
    {
        get { return this.workHours; }
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHours = value;
        }
    }

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    private decimal CalculateSalaryPerHour()
    {
        return WeekSalary / (WorkHours * 5.0m);
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}\r\n" +
               $"Last Name: {this.LastName}\r\n" +
               $"Week Salary: {this.WeekSalary:f2}\r\n" +
               $"Hours per day: {this.WorkHours:f2}\r\n" +
               $"Salary per hour: {this.CalculateSalaryPerHour():f2}";
    }
}