using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Strings
{
    public class ReverseString
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> reversed = new Stack<char>(input);
            Console.WriteLine(string.Join("",reversed));
        }
    }
}
