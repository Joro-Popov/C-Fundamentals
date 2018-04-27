using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        public DetailsPrinter()
        {

        }

        public string PrintDetails(IList<Employee> employees)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Employee employee in employees)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString();
        }
    }
}
