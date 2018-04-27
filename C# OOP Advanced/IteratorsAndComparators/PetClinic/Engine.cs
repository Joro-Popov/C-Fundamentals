using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private ClinicManager manager;

    public Engine(ClinicManager manager)
    {
        this.manager = manager;
    }

    public void Run()
    {
        int n = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < n; counter++)
        {
            List<string> args = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = args[0];
            args.RemoveAt(0);

            switch (command)
            {
                case "Create":
                    string param = args[0];
                    args.RemoveAt(0);

                    if (param == "Pet")
                    {
                        manager.CreatePet(args); 
                    }
                    else
                    {
                        try
                        {
                            manager.CreateClinic(args);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;

                case "Add":
                    Console.WriteLine(manager.Add(args)); break;

                case "Release":
                    Console.WriteLine(manager.Release(args[0])); break;

                case "HasEmptyRooms":
                    Console.WriteLine(manager.HasEmptyRooms(args[0])); break;

                case "Print":
                    if (args.Count > 1)
                    {
                        manager.Print(args[0], int.Parse(args[1]));
                    }
                    else
                    {
                        manager.Print(args[0]);
                    }
                    break;
            }
        }
    }
}
