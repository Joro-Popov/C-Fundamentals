using System;
using System.Linq;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        CustomList<string> myList = new CustomList<string>();

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            string[] args = command.Split(' ');

            string cmd = args[0];

            switch (cmd)
            {
                case "Add":
                    myList.Add(args[1]); break;

                case "Remove":
                    myList.Remove(int.Parse(args[1]));
                    break;

                case "Contains":
                    Console.WriteLine(myList.Contains(args[1]));
                    break;

                case "Swap":
                    int index1 = int.Parse(args[1]);
                    int index2 = int.Parse(args[2]);
                    myList.Swap(index1, index2);
                    break;

                case "Greater":
                    Console.WriteLine(myList.CountGreaterThan(args[1]));
                    break;

                case "Max":
                    Console.WriteLine(myList.Max());
                    break;

                case "Min":
                    Console.WriteLine(myList.Min());
                    break;

                case "Sort":
                    myList.Sort();
                    break;

                case "Print":
                    Console.WriteLine(string.Join(Environment.NewLine, myList));
                    break;
            }
        }
    }
}
