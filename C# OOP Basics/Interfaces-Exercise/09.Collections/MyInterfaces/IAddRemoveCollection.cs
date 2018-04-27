using System;
using System.Collections.Generic;
using System.Text;

public interface IAddRemoveCollection<T> :IAddCollection<T>
{
    int AddToStart(T item);
    T RemoveLast();
}
