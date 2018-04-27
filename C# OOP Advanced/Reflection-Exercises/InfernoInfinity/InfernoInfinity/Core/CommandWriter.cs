using System;

namespace InfernoInfinity.Core
{
    public static class CommandWriter
    {
        public static void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

        public static void WriteLine()
        {
            Console.WriteLine();
        }
    }
}