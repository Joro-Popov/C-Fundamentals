using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MyList<T> : IMyList<T>
{
    private List<T> myCollection;

    public MyList()
    {
        this.MyCollection = new List<T>();
    }
    public List<T> MyCollection
    {
        get { return myCollection; }
        set { myCollection = value; }
    }

    public int AddToStart(T item)
    {
        this.MyCollection.Insert(0,item);
        return 0;
    }

    public T RemoveLast()
    {
        T toReturn = default(T);

        if (this.MyCollection.Count > 0)
        {
            toReturn = this.MyCollection[this.MyCollection.Count - 1];
            this.MyCollection.Remove(toReturn);
        }
        return toReturn;
    }
    
    public T RemoveFirst()
    {
        T toRemove = default(T);

        if (this.MyCollection.Count > 0)
        {
            toRemove = this.MyCollection[0];
            this.MyCollection.RemoveAt(0);
        }
        return toRemove;
    }

    public int Used()
    {
        return this.MyCollection.Count;
    }

    public int AddToEnd(T item)
    {
        this.MyCollection.Add(item);
        return this.MyCollection.Count - 1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int index = 0; index < this.MyCollection.Count; index++)
        {
            yield return this.MyCollection[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
