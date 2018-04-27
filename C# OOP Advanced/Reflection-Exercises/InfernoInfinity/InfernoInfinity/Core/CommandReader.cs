using System;
using System.Collections.Generic;

namespace InfernoInfinity.Core
{
    public static class CommandReader
    {
        public static IEnumerable<string> ReadLine()
        {
            return Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}