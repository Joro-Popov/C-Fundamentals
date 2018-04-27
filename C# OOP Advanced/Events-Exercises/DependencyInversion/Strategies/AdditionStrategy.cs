namespace P03_DependencyInversion
{
    using DependencyInversion;
    using DependencyInversion.Contracts;
    using System;

    public class AdditionStrategy : IStrategy
    {
        public void Calculate(object sender, CalculationArgs args)
        {
            int result = args.FirstOperand + args.SecondOperand;

            Console.WriteLine(result);
        }
    }
}
