using System;
using System.Collections.Generic;
using System.Globalization;

public class ErrorFactory
{
    public IError CreateError(List<string> args)
    {
        string level = args[0];
        string time = args[1];
        string message = args[2];

        ReportLevel reportLevel = ParseReportLevel(level);
        DateTime dateTime = DateTime.ParseExact(time, "M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

        return new Error(dateTime, reportLevel, message);
    }

    private ReportLevel ParseReportLevel(string reportLevel)
    {
        Enum.TryParse(reportLevel, out ReportLevel level);
        return level;
    }
}
