﻿namespace DependencyInversion.Strategies
{
    using DependencyInversion.Contracts;
    using System;

    public class DivisionStrategy : IStrategy
    {
        public void Calculate(object sender, CalculationArgs args)
        {
            int result = args.FirstOperand / args.SecondOperand;

            Console.WriteLine(result);
        }
    }
}
