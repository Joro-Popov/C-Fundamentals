namespace WorkForce
{
    using System;
    using System.Collections.Generic;
    using WorkForce.Contracts;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, IEmployee> employees = new Dictionary<string, IEmployee>();
            JobList<IJob> jobs = new JobList<IJob>();
            IInterpretable interpreter = new CommandInterpreter(employees,jobs);

            Engine engine = new Engine(interpreter);

            engine.Run();
        }
    }
}
