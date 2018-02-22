using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Action_Print
{
    public class Startup
    {
        public static void Main()
        {
            void printName(string s) => Console.WriteLine(s);

            List<string> names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
                

            foreach (var name in names)
            {
                printName(name);
            }
        }
    }
}
