using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private SystemManager systemManager;
    
    public Engine()
    {
        this.systemManager = new SystemManager();
    }

    public void Run()
    {
        string command;

        while ((command = Console.ReadLine()) != "System Split")
        {
            List<string> info = command
                .Split(new char[] { ' ', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string cmd = info[0];

            switch (cmd)
            {
                case "RegisterPowerHardware":

                case "RegisterHeavyHardware":
                    this.systemManager.RegisterHardware(info); break;

                case "RegisterLightSoftware":

                case "RegisterExpressSoftware":
                    this.systemManager.RegisterSoftware(info); break;

                case "ReleaseSoftwareComponent":
                    this.systemManager.ReleaseSoftware(info); break;

                case "Analyze":
                    Console.WriteLine(this.systemManager.Analyze()); break;

                case "Dump":
                    this.systemManager.Dump(info);  break;

                case "Restore":
                    this.systemManager.Restore(info); break;

                case "Destroy":
                    this.systemManager.Destroy(info); break;

                case "DumpAnalyze":
                    Console.WriteLine(this.systemManager.DumpAnalyze());
                    break;
            }
        }
        Console.WriteLine(this.systemManager.GetSystemInfo());
    }
}
