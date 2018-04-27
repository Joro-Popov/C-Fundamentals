using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomStack<T> : IEnumerable<T>
{
    private List<T> data;

    public CustomStack()
    {
        this.data = new List<T>();
    }

    public void Push(T item)
    {
        this.data.Add(item);
    }

    public T Pop()
    {
        if (this.data.Count == 0)
        {
            throw new InvalidOperationException("No elements");
        }
        T current = this.data[this.data.Count - 1];
        this.data.RemoveAt(this.data.Count - 1);
        return current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.data.Count - 1; i >= 0; i--)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.data.GetEnumerator();
    }
}
