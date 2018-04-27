using DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database
{
    public class Database<T> : IEnumerable<T>
        where T : Person
    {
        private const int ARRAY_CAPACITY = 16;

        private T[] data;

        public Database(params T[] inputData)
        {
            this.Data = inputData;
        }

        public int Length => this.Data.Length;

        public int ElementsCount => this.Data.Where(n => n != null).ToArray().Length;
        
        public T this[int index]
        {
            get { return this.data[index]; }
            set { this.data[index] = value; }
        }

        public T[] Data
        {
            get { return this.data; }
            private set
            {
                if (value.Length == 0)
                {
                    this.data = new T[ARRAY_CAPACITY];
                }
                else if (value.Length > ARRAY_CAPACITY)
                {
                    throw new InvalidOperationException("Out of range!");
                }
                else
                {
                    this.data = value;
                }
            }
        }

        public void Add(T item)
        {
            if (this.ElementsCount >= ARRAY_CAPACITY)
            {
                throw new InvalidOperationException("Out of Range!");
            }

            if (this.Data.All(u => u == null))
            {
                this.Data[0] = item;
            }
            else
            {
                if (this.Data.Where(u => u != null).Any(u => u.Username == item.Username))
                {
                    throw new InvalidOperationException("Username exists!");
                }
                else if (this.Data.Where(u => u != null).Any(u => u.Id == item.Id))
                {
                    throw new InvalidOperationException("Id exists!");
                }
                else
                {
                    this.Data[this.ElementsCount] = item;
                }
            }
           
        }

        public void Remove()
        {
            if (this.ElementsCount == 0)
            {
                throw new InvalidOperationException("Empty array!");
            }
            this.Data[this.ElementsCount - 1] = null;
        }

        public T FindById(long id)
        {
            if (id < 0)
            {
                throw new InvalidOperationException("Id must be positive number!");
            }
            else if (this.Data.Where(u => u != null).All(u => u.Id != id))
            {
                throw new InvalidOperationException("No such user with that Id!");
            }

            return this.Data.FirstOrDefault(u => u.Id == id);
        }

        public T FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(username))
            {
                throw new InvalidOperationException("Username cannot be null!");
            }
            else if (this.Data.Where(u => u != null).All(u => u.Username != username))
            {
                throw new InvalidOperationException("No such username found!");
            }
            return this.Data.FirstOrDefault(u => u.Username == username);
        }

        public T[] Fetch()
        {
            return this.Data.Where(i => i != default(T)).ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int count = 0; count < this.ElementsCount; count++)
            {
                yield return this.Data[count];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }
    }
}
