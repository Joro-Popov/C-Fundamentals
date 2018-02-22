using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Balanced_Parenthesis
{
    public class Balance
    {
        public static void Main()
        {
            string sequence = Console.ReadLine();
            bool isBalanced = false;
            Stack<char> openBrackets = new Stack<char>();

            foreach (var bracket in sequence)
            {
                if (bracket == '(' || bracket == '{' || bracket == '[')
                {
                    openBrackets.Push(bracket);
                    continue;
                }
                if (openBrackets.Count > 0)
                {
                    char openBracket = openBrackets.Pop();

                    if (openBracket == '(' && bracket == ')' ||
                        openBracket == '{' && bracket == '}' ||
                        openBracket == '[' && bracket == ']')
                    {
                        isBalanced = true;
                        continue;
                    }
                    isBalanced = false;
                    break;
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
