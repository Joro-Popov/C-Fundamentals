using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.Matching_Brackets
{
    public class Matching
    {
        public static void Main()
        {
            string expression = Console.ReadLine();
            Stack<int> openBracketIndex = new Stack<int>();

            for (int index = 0; index < expression.Length; index++)
            {
                if (expression[index] == '(')
                {
                    openBracketIndex.Push(index);
                }
                else if (expression[index] == ')')
                {
                    int start = openBracketIndex.Pop();
                    string substring = expression.Substring(start, index - start + 1);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
