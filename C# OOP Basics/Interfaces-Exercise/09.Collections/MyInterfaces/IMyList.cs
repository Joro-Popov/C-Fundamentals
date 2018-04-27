using System;
using System.Collections.Generic;
using System.Text;

public interface IMyList<T> : IAddRemoveCollection<T>
{ 
    T RemoveFirst();
    int Used();
}
