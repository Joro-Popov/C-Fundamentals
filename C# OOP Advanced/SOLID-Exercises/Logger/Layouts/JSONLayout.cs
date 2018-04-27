using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class JSONLayout : Layout
{
    const string OUTPUT_FORMAT = "{{ DateTime: {0} : ErrorLevel: {1} : Message: {2} }}";

    public override string FormatError(IError error)
    {
        string date = error.DateTime.ToString(DATE_FORMAT, CultureInfo.InvariantCulture);
        string output = string.Format(OUTPUT_FORMAT, date, error.ReportLevel, error.Message);
        return output;
    }
}
