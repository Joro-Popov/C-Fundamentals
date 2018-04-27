using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class SimpleLayout : Layout
{
    const string OUTPUT_FORMAT = "{0} - {1} - {2}";
    
    public override string FormatError(IError error)
    {
        string date = error.DateTime.ToString(DATE_FORMAT, CultureInfo.InvariantCulture);
        string errorOutput = string.Format(OUTPUT_FORMAT, date, error.ReportLevel.ToString(), error.Message);

        return errorOutput;
    }
}
