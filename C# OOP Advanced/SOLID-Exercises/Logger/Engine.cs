using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private ILogger logger;
    private ErrorFactory errorFactory;
    private ICollection<IError> errors;

    public Engine(ILogger logger, ICollection<IError> errors, ErrorFactory factory)
    {
        this.logger = logger;
        this.errorFactory = factory;
        this.errors = errors;
    }

    public void Run()
    {
        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            List<string> errorArgs = command
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            IError error = this.errorFactory.CreateError(errorArgs);
            this.errors.Add(error);
        }

        foreach (var error in this.errors)
        {
            this.logger.Log(error);
        }

        Console.WriteLine(logger.LoggerInfo());
    }
}
