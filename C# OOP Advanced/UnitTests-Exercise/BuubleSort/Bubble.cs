using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubleSort
{
    public class Bubble<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private T[] data;

        public Bubble(IEnumerable<T> data)
        {
            this.data = data.ToArray();
        }

        public  void Sort()
        {
            for (int i = 0; i < this.data.Count(); i++)
            {
                for (int j = 0; j < this.data.Count() - 1; j++)
                {
                    T firstItem = this.data[j];
                    T secondItem = this.data[j + 1];

                    if (firstItem.CompareTo(secondItem) == 1)
                    {
                        T temp = this.data[j + 1];
                        this.data[j + 1] = this.data[j];
                        this.data[j] = temp;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
