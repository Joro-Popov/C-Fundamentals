namespace P03_DependencyInversion
{
    using DependencyInversion;
    using DependencyInversion.Contracts;
    using DependencyInversion.Strategies;
    using System;

    public class PrimitiveCalculator
    {
        private IStrategy strategy;
        public event EventHandler<CalculationArgs> Calculate;

        public PrimitiveCalculator()
        {
            this.strategy = new AdditionStrategy();
            this.Calculate += strategy.Calculate;
        }

        public PrimitiveCalculator(IStrategy strategy): this()
        {
            this.ChangeStrategy(strategy);
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.Calculate -= this.strategy.Calculate;
            this.strategy = strategy;
            this.Calculate += strategy.Calculate;
        }

        public void OnCalculation(CalculationArgs args)
        {
            this.Calculate?.Invoke(this,args);
        }
    }
}
