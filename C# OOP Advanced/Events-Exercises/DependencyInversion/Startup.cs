namespace DependencyInversion
{
    using DependencyInversion.Contracts;
    using P03_DependencyInversion;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var calculator = new PrimitiveCalculator();
            var operatorFactory = new OperatorFactory();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] args = command.Split();

                string cmd = args[0];

                switch (cmd)
                {
                    case "mode":
                        char @operator = char.Parse(args[1]);
                        var strategy = operatorFactory.CreateStrategy(@operator);

                        calculator.ChangeStrategy(strategy);
                        break;

                    default:
                        int firstNum = int.Parse(args[0]);
                        int secondNum = int.Parse(args[1]);

                        var nums = new CalculationArgs(firstNum, secondNum);
                        calculator.OnCalculation(nums);

                        break;
                }
            }
        }
       
    }
}
