namespace DependencyInversion
{
    using DependencyInversion.Contracts;
    using DependencyInversion.Strategies;
    using P03_DependencyInversion;
    using System;

    public class OperatorFactory
    {
        public IStrategy CreateStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+': return new AdditionStrategy();
                case '-': return new SubtractionStrategy();
                case '*': return new MultiplicationStrategy();
                case '/': return new DivisionStrategy();
                default: return null;
            }
        }
    }
}
