using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorTest
{
    public class ListIterator : IListIterator
    {
        private IEnumerable<string> data;
        private int index;

        public ListIterator(IEnumerable<string> collection)
        {
            this.Data = collection;
            this.index = 0;
        }

        public IEnumerable<string> Data
        {
            get { return this.data; }
            private set
            {
                this.data = value ?? throw new ArgumentNullException("Invalid Operation!");
            }
        }

        public int Count => this.data.Count();

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
            if (this.index == this.data.Count() - 1)
            {
                return false;
            }
            return true;
        }

        public void Print()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.data.ElementAt(this.index));
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int counter = 0; counter < this.Count; counter++)
            {
                yield return this.data.ElementAt(counter);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }
    }
}
