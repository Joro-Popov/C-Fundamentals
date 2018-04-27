using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class Person
    {
        private string username;
        private long id;

        public Person(string username, long id)
        {
            this.Username = username;
            this.Id = id;
        }

        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null ot empty!");
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                else
                {
                    this.username = value;
                }
            }
        }

        public long Id
        {
            get { return this.id; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Id value must be positive number!");
                }
                this.id = value;
            }
        }
    }
}
