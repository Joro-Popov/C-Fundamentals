using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private T[] data;

    public CustomList()
    {
        this.data = new T[4];
    }

    public int InnerArraySize => this.data.Length;

    public int CountOfElements { get; private set; }

    public T this[int index]
    {
        get { return this.data[index]; }
        set { this.data[index] = value; }
    }

    public void Add(T element)
    {
        this.CountOfElements++;

        if (this.CountOfElements > this.InnerArraySize)
        {
            T[] newData = new T[this.InnerArraySize * 2];
            Array.Copy(this.data, newData, this.InnerArraySize);
            this.data = newData;
        }

        this.data[this.CountOfElements - 1] = element;
    }

    public T Remove(int index)
    {
        T item = this.data[index];

        this.CountOfElements--;
        
        for (int count = index; count < this.CountOfElements; count++)
        {
            this.data[count] = this.data[count + 1];
        }

        this.data[this.CountOfElements] = default(T);

        if (this.CountOfElements < this.InnerArraySize / 3)
        {
            T[] newData = new T[this.InnerArraySize / 2];
            Array.Copy(this.data, newData, this.CountOfElements);
            this.data = newData;
        }

        return item;
    }

    public bool Contains(T element)
    {
        for (int index = 0; index < this.CountOfElements; index++)
        {
            if (this.data[index].Equals(element))
            {
                return true;
            }
        }
        return false;
    }

    public void Swap(int index1, int index2)
    {
        T temp = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;

        for (int index = 0; index < CountOfElements; index++)
        {
            if (this.data[index].CompareTo(element) == 1)
            {
                count++;
            }
        }
        return count;
    }
    
    public void Sort()
    {
        Array.Sort(this.data, 0, this.CountOfElements);
    }

    public T Max()
    {
        T maxElement = this.data[0];

        for (int index = 0; index < this.CountOfElements; index++)
        {
            T currentElement = this.data[index];
            int comparison = currentElement.CompareTo(maxElement);

            if (comparison == 1)
            {
                maxElement = currentElement;
            }
        }

        return maxElement;
    }

    public T Min()
    {
        T minElement = this.data[0];

        for (int index = 0; index < this.CountOfElements; index++)
        {
            T currentElement = this.data[index];
            int comparison = currentElement.CompareTo(minElement);

            if (comparison == -1)
            {
                minElement = currentElement;
            }
        }
        return minElement;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int index = 0; index < this.CountOfElements; index++)
        {
            yield return this.data[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
