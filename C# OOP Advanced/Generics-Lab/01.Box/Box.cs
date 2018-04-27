using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private readonly List<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public int Count => this.items.Count;

    public void Add(T item) => this.items.Add(item);
    
    public T Remove()
    {
        T element = this.items.Last();
        int index = this.items.Count - 1;
        this.items.RemoveAt(index);
        return element;
    }
}
