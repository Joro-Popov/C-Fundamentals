using System;
using System.Linq;
using System.Collections.Generic;

namespace _13._TriFunction
{
    public class Startup
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => n.ToCharArray().Sum(c => c) >= num)
                .ToList();

            if (names.Count != 0)
            {
                Console.WriteLine(names[0]);
            }
            
        }
    }
}
