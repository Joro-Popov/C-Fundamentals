using System;
using System.Linq;

public class Engine
{
    private const string TerminatingCommand = "Shutdown";

    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter manager;

    public Engine(IWriter writer, IReader reader, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.manager = commandInterpreter;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            var input = Console.ReadLine();
            var arguments = input.Split().ToList();

            if (arguments[0] == TerminatingCommand)
            {
                isRunning = false;
            }

            var result = this.manager.ProcessCommand(arguments);

            this.writer.WriteLine(result);
        }
    }
}