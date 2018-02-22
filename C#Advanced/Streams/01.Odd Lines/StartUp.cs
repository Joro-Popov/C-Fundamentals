using System;
using System.IO;

namespace _01.Odd_Lines
{
    public class StartUp
    {
        public static void Main()
        {
            using (var reader = new StreamReader("Text.txt"))
            {
                int counter = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;

                    line = reader.ReadLine();
                }
            }
        }
    }
}
