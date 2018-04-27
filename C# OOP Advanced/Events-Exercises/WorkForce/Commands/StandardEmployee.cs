namespace WorkForce.Commands
{
    using System;
    using System.Collections.Generic;
    using WorkForce.Contracts;
    using WorkForce.EmployeeModels;

    public class StandardEmployee : Command
    {
        [Inject]
        private IDictionary<string, IEmployee> employees;

        public StandardEmployee(string[] data) : base(data)
        {

        }

        public override void Execute()
        {
            string name = this.Data[1];
            var type = typeof(WorkForce.EmployeeModels.StandardEmployee);
            var employee = (IEmployee)Activator.CreateInstance(type, new object[] { name});

            this.employees[name] = employee;
        }
    }
}
