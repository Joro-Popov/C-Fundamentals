using System;

public class Startup
{
    static void Main()
    {
        ClinicManager manager = new ClinicManager();
        Engine engine = new Engine(manager);
        engine.Run();
    }
}
