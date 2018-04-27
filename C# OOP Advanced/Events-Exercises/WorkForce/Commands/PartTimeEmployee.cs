namespace WorkForce.Commands
{
    using System;
    using System.Collections.Generic;
    using WorkForce.Contracts;

    public class PartTimeEmployee : Command
    {
        [Inject]
        private IDictionary<string, IEmployee> employees;

        public PartTimeEmployee(string[] data) : base(data)
        {

        }

        public override void Execute()
        {
            string name = this.Data[1];
            var type = typeof(WorkForce.EmployeeModels.PartTimeEmployee);
            var employee = (IEmployee)Activator.CreateInstance(type, new object[] { name});

            this.employees[name] = employee;
        }
    }
}
