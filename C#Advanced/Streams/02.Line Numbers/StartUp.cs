using System;
using System.IO;

namespace _02.Line_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            int count = 0;

            using (var reader = new StreamReader("input.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    string readLine = reader.ReadLine();

                    while (readLine != null)
                    {
                        writer.WriteLine($"{count}. {readLine}",false);
                        count++;
                        readLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
