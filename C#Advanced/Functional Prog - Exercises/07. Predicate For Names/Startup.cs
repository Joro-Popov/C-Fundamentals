using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Predicate_For_Names
{
    public static class MyExtensions
    {
        public static List<string> AddPrefix(this List<string> names, Func<string, bool> Check)
        {
            List<string> result = new List<string>();

            foreach (var name in names)
            {
                if (Check(name))
                {
                    result.Add(name);
                }
            }
            return result;
        }
    }


    public class Startup
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            names = names.AddPrefix(n => n.Length <= length);

            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
        
    }
}
