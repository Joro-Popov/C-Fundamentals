using System;

namespace InfernoInfinity.Commands
{
    public class END : Command
    {
        public END(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}