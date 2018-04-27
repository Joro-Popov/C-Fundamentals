namespace WorkForce.EmployeeModels
{
    using System;

    public class StandardEmployee : Employee
    {
        private const int WORK_HOURS = 40;

        public StandardEmployee(string name) : base(name, WORK_HOURS)
        {

        }
    }
}
