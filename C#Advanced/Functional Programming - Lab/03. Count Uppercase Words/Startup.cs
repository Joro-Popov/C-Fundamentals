using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Count_Uppercase_Words
{
    public class Stratup
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .ToList();

            Console.WriteLine(string.Join("\r\n",words));
        }
    }
}
