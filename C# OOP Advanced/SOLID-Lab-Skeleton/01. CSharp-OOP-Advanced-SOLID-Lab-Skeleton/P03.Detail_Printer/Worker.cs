using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    class Worker : Employee
    {
        public int Salary { get; protected set; }

        public Worker(string name, int salary) : base(name)
        {
            this.Salary = salary;
        }
        public override string ToString()
        {
            string result = $"{base.ToString()}{Environment.NewLine}" +
                            $"Salary: {this.Salary}";
            return result;
        }
    }
}
