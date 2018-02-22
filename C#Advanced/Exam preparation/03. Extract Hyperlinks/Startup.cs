using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace _03._Extract_Hyperlinks
{
    public class Startup
    {
        public static void Main()
        {
            StringBuilder text = new StringBuilder();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                text.Append(input);
            }
            Regex pattern = new Regex(@"<a[^<>]*href\s*=\s*(?<value>[^>]*)(?=[^\s*""'>]*)");

        }
    }
}
