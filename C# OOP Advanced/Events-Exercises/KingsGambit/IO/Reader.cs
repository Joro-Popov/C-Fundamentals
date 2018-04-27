namespace KingsGambit
{
    using System;
    using Contracts;

    public class Reader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
