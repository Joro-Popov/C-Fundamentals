using System;
using System.Collections.Generic;
using System.Text;

public static class Comparator
{
    public static int Compare<T>(IEnumerable<T> collection, T element)
        where T : IComparable<T>
    {
        int count = 0;

        foreach (var item in collection)
        {
            if (item.CompareTo(element) == 1)
            {
                count++;
            }
        }
        return count;
    }
}
