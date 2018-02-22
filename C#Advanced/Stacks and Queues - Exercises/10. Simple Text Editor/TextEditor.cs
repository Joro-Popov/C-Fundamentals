using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._Simple_Text_Editor
{
    public class TextEditor
    {
        public static void Main()
        {
            int operationsCount = int.Parse(Console.ReadLine());
            var lastStrings = new Stack<string>();
            string text = string.Empty;
            lastStrings.Push(text);

            for (int i = 0; i < operationsCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string type = arguments[0];

                if (type == "1")
                {
                    string toAppend = arguments[1];
                    text += toAppend;
                    lastStrings.Push(toAppend);
                    
                }
                else if (type == "2")
                {
                    int count = int.Parse(arguments[1]);
                    text = text.Substring(0, text.Length - count);
                    lastStrings.Push(text);
                }
                else if (type == "3")
                {
                    int index = int.Parse(arguments[1]);

                    Console.WriteLine(text[index - 1]);
                }
                else
                {
                    lastStrings.Pop();
                    text = lastStrings.Peek();
                }
            }
        }
    }
}
