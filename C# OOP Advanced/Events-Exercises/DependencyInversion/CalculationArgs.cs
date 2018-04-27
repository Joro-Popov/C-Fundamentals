namespace DependencyInversion
{
    using System;

    public class CalculationArgs
    {
        public CalculationArgs(int first, int second)
        {
            this.FirstOperand = first;
            this.SecondOperand = second;
        }

        public int FirstOperand { get; private set; }

        public int SecondOperand { get; private set; }
    }
}
