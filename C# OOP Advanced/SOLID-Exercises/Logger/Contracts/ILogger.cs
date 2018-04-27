using System;
using System.Collections.Generic;
using System.Text;

public interface ILogger
{
    IEnumerable<IAppender> Appenders { get; }

    void Log(IError error);

    string LoggerInfo();
}