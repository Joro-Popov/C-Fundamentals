using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SystemManager
{
    private HardwareFactory hardwareFactory;
    private SoftwareFactory softwareFactory;
    private Dictionary<string, Hardware> hardwares;
    private Dump dump;

    public SystemManager()
    {
        this.hardwareFactory = new HardwareFactory();
        this.softwareFactory = new SoftwareFactory();
        this.hardwares = new Dictionary<string, Hardware>();
        this.dump = new Dump();
    }

    public void RegisterHardware(List<string> args)
    {
        Hardware hardware = this.hardwareFactory.CreateHardware(args);
        this.hardwares[hardware.Name] = hardware;
    }

    public void RegisterSoftware(List<string> args)
    {
        Software software = this.softwareFactory.CreateSoftware(args);

        if (this.hardwares.ContainsKey(software.HardwareComponent))
        {
            this.hardwares[software.HardwareComponent].AddSoftware(software);
        }
    }

    public void ReleaseSoftware(List<string> args)
    {
        string hardwareComponent = args[1];
        string softwareComponent = args[2];

        if (this.hardwares.ContainsKey(hardwareComponent))
        {
            this.hardwares[hardwareComponent].ReleaseSoftware(softwareComponent);
        }
    }

    public string Analyze()
    {
        int hardwareComponents = this.hardwares.Count();
        int softwareComponents = this.hardwares.Values.Sum(s => s.SoftwareComponents.Count);
        int operationalMemory = this.hardwares.Values.Sum(s => s.SoftwareComponents.Sum(c => c.MemoryConsumption));
        int maxMemory = this.hardwares.Values.Sum(s => s.MaxMemory);
        int totalCapacityConsumption = this.hardwares.Values.Sum(s => s.SoftwareComponents.Sum(c => c.CapacityConsumption));
        int maxCapacity = this.hardwares.Values.Sum(s => s.MaxCapacity);

        return $"System Analysis\r\n" +
               $"Hardware Components: {hardwareComponents}\r\n" +
               $"Software Components: {softwareComponents}\r\n" +
               $"Total Operational Memory: {operationalMemory} / {maxMemory}\r\n" +
               $"Total Capacity Taken: {totalCapacityConsumption} / {maxCapacity}";
    }

    public void Dump(List<string> args)
    {
        string hardwareComponent = args[1];

        if (this.hardwares.ContainsKey(hardwareComponent))
        {
            this.dump.TemporaryDeleted.Add(hardwares[hardwareComponent]);
            this.hardwares.Remove(hardwareComponent);
        }
    }

    public void Restore(List<string> args)
    {
        string hardwareComponent = args[1];
        this.dump.Restore(hardwareComponent, this.hardwares);
    }

    public void Destroy(List<string> args)
    {
        string hardwareComponent = args[1];
        this.dump.Destroy(hardwareComponent);
    }

    public string DumpAnalyze()
    {
        return this.dump.Analyze();
    }

    public string GetSystemInfo()
    {
        StringBuilder result = new StringBuilder();
        foreach (var hard in this.hardwares.OrderByDescending(w => w.Value.GetType().Name))
        {
            Hardware component = hard.Value;

            var name = hard.Key;
            var expressSoftwareComponents = component.SoftwareComponents.Where(s => s is ExpressSoftware).Count();
            var lightSoftwareComponents = component.SoftwareComponents.Where(s => s is LightSoftware).Count();
            var memoryConsumption = component.SoftwareComponents.Sum(s => s.MemoryConsumption);
            var capacityConsumption = component.SoftwareComponents.Sum(s => s.CapacityConsumption);

            result.AppendLine($"Hardware Component - {name}\r\n" +
                              $"Express Software Components - {expressSoftwareComponents}\r\n" +
                              $"Light Software Components - {lightSoftwareComponents}\r\n" +
                              $"Memory Usage: {memoryConsumption} / {component.MaxMemory}\r\n" +
                              $"Capacity Usage: {capacityConsumption} / {component.MaxCapacity}\r\n" +
                              $"Type: {component.Type}");

            if (component.SoftwareComponents.Count == 0)
            {
                result.AppendLine($"Software Components: None");
            }
            else
            {
                result.AppendLine($"Software Components: {string.Join(", ", component.SoftwareComponents)}");
            }
        }
        return result.ToString().Trim();
    }
}
