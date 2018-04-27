using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StonesCollection<T> : IEnumerable<T>
{
    private IEnumerable<T> data;

    public StonesCollection(IEnumerable<T> collection)
    {
        this.data = collection;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.data.Count(); i+=2)
        {
            yield return this.data.ElementAt(i);
        }

        List<T> elements = new List<T>();

        for (int i = 0; i < this.data.Count(); i ++)
        {
            if (i % 2 == 1)
            {
                elements.Add(this.data.ElementAt(i));
            }
        }

        elements.Reverse();

        for (int i = 0; i < elements.Count; i++)
        {
            yield return elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.data.GetEnumerator();
    }
}
