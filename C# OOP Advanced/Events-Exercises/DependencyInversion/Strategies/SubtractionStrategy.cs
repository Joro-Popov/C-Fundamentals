namespace P03_DependencyInversion
{
    using DependencyInversion;
    using DependencyInversion.Contracts;
    using System;

    public class SubtractionStrategy : IStrategy
    {
        public void Calculate(object sender, CalculationArgs args)
        {
            int result = args.FirstOperand - args.SecondOperand;

            Console.WriteLine(result);
        }
    }
}
