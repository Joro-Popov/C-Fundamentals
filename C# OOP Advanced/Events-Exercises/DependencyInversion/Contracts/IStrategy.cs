namespace DependencyInversion.Contracts
{
    using System;

    public interface IStrategy
    {
        void Calculate(object sender, CalculationArgs args);
    }
}
