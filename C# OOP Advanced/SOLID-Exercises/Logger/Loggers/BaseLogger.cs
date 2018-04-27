using System;
using System.Collections.Generic;
using System.Text;

public abstract class BaseLogger : ILogger
{
    protected BaseLogger(IEnumerable<IAppender> appenders)
    {
        this.Appenders = appenders;
    }

    public IEnumerable<IAppender> Appenders { get; private set; }

    public void Log(IError error)
    {
        foreach (var appender in this.Appenders)
        {
            if (appender.ReportLevel <= error.ReportLevel)
            {
                appender.AppendMessage(error);
            }
        }
    }

    public string LoggerInfo()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Logger info{Environment.NewLine}");

        foreach (var appender in this.Appenders)
        {
            sb.AppendLine($"{appender.ToString()}{Environment.NewLine}");
        }

        return sb.ToString().Trim();
    }
}
