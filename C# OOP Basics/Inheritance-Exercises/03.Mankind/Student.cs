using System;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        private set
        {
            if (!IsFacultyNumberValid(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}\r\n" +
               $"Last Name: {this.LastName}\r\n" +
               $"Faculty number: {this.FacultyNumber}\r\n";
    }

    private bool IsFacultyNumberValid(string value)
    {
        Regex pattern = new Regex(@"^[0-9A-z]{5,10}$");
        if (pattern.IsMatch(value))
        {
            return true;
        }
        return false;
    }
}