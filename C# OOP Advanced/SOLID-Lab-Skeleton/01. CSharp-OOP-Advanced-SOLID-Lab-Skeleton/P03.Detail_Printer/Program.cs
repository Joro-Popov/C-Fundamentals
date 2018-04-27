using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Program
    {
        public static void Main()
        {
            List<string> documents = new List<string>()
            {
                "doc1","doc2","doc3"
            };

            List<Employee> employees = new List<Employee>()
            {
                new Employee("Gosho"),
                new Manager("Pesho",documents),
                new Worker("Ivan",2000)
            };

            DetailsPrinter dp = new DetailsPrinter();

            Console.WriteLine(dp.PrintDetails(employees));
        }
    }
}
