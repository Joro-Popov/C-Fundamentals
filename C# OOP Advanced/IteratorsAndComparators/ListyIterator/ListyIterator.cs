using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
    private ICollection<T> data;
    private int index;

    public ListyIterator(ICollection<T> collection)
    {
        this.data = collection;
        this.index = 0;
    }
    
    public bool Move()
    {
        if (HasNext())
        {
            ++index;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        if (this.index == this.data.Count - 1)
        {
            return false;
        }
        return true;
    }

    public void Print()
    {
        if (this.data.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.data.ElementAt(this.index));
    }
    
    public void PrintAll()
    {
        if (this.data.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(string.Join(' ',this.data));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.data.Count; i++)
        {
            yield return this.data.ElementAt(i);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.data.GetEnumerator();
    }
}
