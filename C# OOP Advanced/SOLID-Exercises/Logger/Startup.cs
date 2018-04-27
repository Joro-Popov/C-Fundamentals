using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        ILogger logger = InitializeLogger();
        ErrorFactory errorFactory = new ErrorFactory();
        ICollection<IError> errors = new List<IError>();

        Engine engine = new Engine(logger, errors, errorFactory);
        engine.Run();
    }

    static ILogger InitializeLogger()
    {
        ICollection<IAppender> appenders = new List<IAppender>();
        LayoutFactory layoutFactory = new LayoutFactory();
        AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

        int n = int.Parse(Console.ReadLine());

        for (int count = 0; count < n; count++)
        {
            List<string> args = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            
            IAppender appender = appenderFactory.CreateAppender(args);
            appenders.Add(appender);
        }

        ILogger logger = new Logger(appenders.ToArray());

        return logger;
    }
}
