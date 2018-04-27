using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class AppenderFactory
{
    private LayoutFactory layoutFactory;

    public AppenderFactory(LayoutFactory layoutFactory)
    {
        this.layoutFactory = layoutFactory;
    }

    public IAppender CreateAppender(List<string> args)
    {
        string appenderType = args[0];
        string layoutType = args[1];

        ILayout layout = this.layoutFactory.CreateLayout(layoutType);
        ReportLevel reportLevel = ReportLevel.INFO;

        if (args.Count == 3)
        {
            string level = args[2];
            reportLevel = ParseReportLevel(level);
        }
        
        switch (appenderType)
        {
            case "ConsoleAppender":
                return new ConsoleAppender(layout, reportLevel);

            case "FileAppender":
                return new FileAppender(layout, reportLevel, new LogFile());

            default: throw new ArgumentException("Invalid Appender Type!");
        }
    }

    private ReportLevel ParseReportLevel(string reportLevel)
    {
        Enum.TryParse(reportLevel, out ReportLevel level);
        return level;
    }
}
