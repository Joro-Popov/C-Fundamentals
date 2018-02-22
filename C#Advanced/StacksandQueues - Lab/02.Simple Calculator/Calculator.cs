using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.Simple_Calculator
{
    public class Calculator
    {
        public static void Main()
        {
            string[] expression = Console.ReadLine()
                .Split(new char[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries);
                

            Stack<string> result = new Stack<string>(expression.Reverse());

            while (result.Count > 1)
            {
                int firstOperand = int.Parse(result.Pop());
                string operation = result.Pop();
                int secondOperand = int.Parse(result.Pop());
                int res = 0;

                switch (operation)
                {
                    case "+": res = firstOperand + secondOperand; break;
                    case "-": res = firstOperand - secondOperand; break;
                }

                result.Push(res.ToString());
            }

            Console.WriteLine(string.Join("",result));
        }
    }
}
