namespace P02_BlackBoxInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            string input;

            var type = typeof(BlackBoxInteger);

            var constructor = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

            var instance = (BlackBoxInteger)constructor[0].Invoke(new object[] { 0});

            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            while ((input = Console.ReadLine()) != "END")
            {
                List<string> args = input
                    .Split('_', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = args[0];

                int value = int.Parse(args[1]);

                switch (command)
                {
                    case "Add":
                        Print(methods, instance, type, value, "Add");
                        break;

                    case "Subtract":
                        Print(methods, instance, type, value, "Subtract");
                        break;

                    case "Multiply":
                        Print(methods, instance, type, value, "Multiply");
                        break;

                    case "Divide":
                        Print(methods, instance, type, value, "Divide");
                        break;

                    case "LeftShift":
                        Print(methods, instance, type, value, "LeftShift");
                        break;

                    case "RightShift":
                        Print(methods, instance, type, value, "RightShift");
                        break;
                }
            }
        }
        public static void Print(MethodInfo[] methods,BlackBoxInteger instance,Type type, int value, string methodName)
        {
            var AddMethod = methods.FirstOrDefault(m => m.Name == methodName);

            AddMethod.Invoke(instance, new object[] { value });

            var field = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(instance);

            Console.WriteLine(field);
        }
    }
}
