using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;
    
    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public DraftManager DraftManager
    {
        get { return draftManager; }
        private set { draftManager = value; }
    }

    public void Run()
    {
        string command;

        while ((command = Console.ReadLine()) != "Shutdown")
        {
            List<string> args = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string cmd = args[0];
            args.RemoveAt(0);

            switch (cmd)
            {
                case "RegisterHarvester":
                    Console.WriteLine(this.DraftManager.RegisterHarvester(args));
                    break;

                case "RegisterProvider":
                    Console.WriteLine(this.DraftManager.RegisterProvider(args));
                    break;

                case "Day":
                    Console.WriteLine(this.DraftManager.Day()); break;

                case "Mode":
                    Console.WriteLine(this.DraftManager.Mode(args)); break;

                case "Check":
                    Console.WriteLine(this.DraftManager.Check(args)); break;
            }
        }
        Console.WriteLine(this.DraftManager.ShutDown());
    }
}
