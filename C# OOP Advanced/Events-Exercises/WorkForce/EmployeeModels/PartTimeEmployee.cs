namespace WorkForce.EmployeeModels
{
    using System;

    public class PartTimeEmployee : Employee
    {
        private const int WORK_HOURS = 20;

        public PartTimeEmployee(string name) : base(name, WORK_HOURS)
        {
            
        }
    }
}
