using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _03._Softuni_Numerals
{
    public class Startup
    {
        public static string ConvertToBaseSoft(string numeralString)
        {
            StringBuilder converted = new StringBuilder();

            List<string> SoftUniNumbers = new List<string>()
            {
                "aa","aba","bcc","cc","cdc"
            };

            int counter = 0;

            if (numeralString.Length < 4)
            {
                return SoftUniNumbers.IndexOf(numeralString).ToString();
            }

            while (counter < numeralString.Length)
            {
                string current = numeralString.Substring(counter, 2);
                int indexOfCurrent = SoftUniNumbers.IndexOf(current);

                if (indexOfCurrent != -1)
                {
                    converted.Append(indexOfCurrent.ToString());
                    counter += 2;
                }
                else
                {
                    current = numeralString.Substring(counter, 3);
                    indexOfCurrent = SoftUniNumbers.IndexOf(current);
                    converted.Append(indexOfCurrent.ToString());
                    counter += 3;
                }
            }

            return converted.ToString();
        }
        public static BigInteger ConvertToBaseTen(string baseSoft)
        {
            BigInteger converted = 0;
            BigInteger counter = (BigInteger)Math.Pow(5, baseSoft.Length);
            Queue<char> tokens = new Queue<char>(baseSoft.Reverse());

            for (BigInteger index = 1; index < counter; index*=5)
            {
                if (tokens.Count > 0)
                {
                    BigInteger temp = (tokens.Dequeue() - 48) * index;
                    converted += temp;
                }
                else
                {
                    break;
                }
            }
            return converted;
        }
        public static void Main()
        {
            string numberalString = Console.ReadLine();
            string baseSoft = ConvertToBaseSoft(numberalString);
            BigInteger converted = ConvertToBaseTen(baseSoft);
            Console.WriteLine(converted);
        }
    }
}
