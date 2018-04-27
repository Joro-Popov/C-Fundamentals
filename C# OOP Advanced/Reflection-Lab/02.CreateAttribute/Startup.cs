using System;

[SoftUni("Ventsi")]
public class Startup
{
    [SoftUni("Gosho")]
    static void Main()
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}
