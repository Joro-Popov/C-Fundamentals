namespace WorkForce.EmployeeModels
{
    using System;
    using WorkForce.Contracts;

    public abstract class Employee : IEmployee
    {
        protected Employee(string name, int workhours)
        {
            this.Name = name;
            this.WorkHours = workhours;
        }

        public string Name { get; private set; }

        public int WorkHours { get; private set; }
    }
}
