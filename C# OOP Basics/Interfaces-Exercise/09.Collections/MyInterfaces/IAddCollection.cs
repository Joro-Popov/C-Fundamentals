using System;
using System.Collections.Generic;
using System.Text;

public interface IAddCollection<T> :IEnumerable<T>
{
    int AddToEnd(T item);
}
