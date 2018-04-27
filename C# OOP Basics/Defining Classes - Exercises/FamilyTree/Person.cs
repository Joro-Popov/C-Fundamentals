using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Birthday { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Childrens { get; set; }
    public Person()
    {
        FirstName = "";
        LastName = "";
        Birthday = "";
        Parents = new List<Person>();
        Childrens = new List<Person>();
    }
    public override string ToString()
    {
        return $"{this.FirstName}";
    }
}
