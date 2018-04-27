using System;
using System.Collections.Generic;
using System.Text;

public class Logger : BaseLogger
{
    public Logger(IEnumerable<IAppender> appenders) 
        : base(appenders)
    {

    }
}
