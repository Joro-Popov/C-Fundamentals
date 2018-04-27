namespace KingsGambit
{
    using System;
    using Contracts;

    public class Writer : IWriter
    {
        public void Write()
        {
            Console.WriteLine();
        }

        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
