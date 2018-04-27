using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

public class LogFile : ILogFile
{
    public LogFile()
    {

    }

    public int Size => File.ReadAllText(this.Path).Where(c => char.IsLetter(c)).Sum(c => c);

    public string Path => "log.txt";

    public void WriteToFile(string message)
    {
        using (StreamWriter writer = new StreamWriter(Path,true))
        {
            writer.WriteLine(message);
        }
    }
}
