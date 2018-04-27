using System;
using System.Collections.Generic;
using System.Text;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x.Name.Length.CompareTo(y.Name.Length) == 0)
        {
            return char.ToLower(x.Name[0]).CompareTo(char.ToLower(y.Name[0]));
        }

        return x.Name.Length.CompareTo(y.Name.Length);
    }
}
