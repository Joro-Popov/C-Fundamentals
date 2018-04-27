using System.Collections.Generic;

namespace IteratorTest
{
    public interface IListIterator : IEnumerable<string>
    {
        int Count { get; }
        IEnumerable<string> Data { get; }

        bool HasNext();
        bool Move();
        void Print();
    }
}