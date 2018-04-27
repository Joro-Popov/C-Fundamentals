using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dump
{
    private List<Hardware> temporaryDeleted;

    public Dump()
    {
        this.TemporaryDeleted = new List<Hardware>();
    }

    public List<Hardware> TemporaryDeleted
    {
        get { return temporaryDeleted; }
        private set { temporaryDeleted = value; }
    }

    public void Restore(string hardware,Dictionary<string,Hardware> hardwares)
    {
        if (this.TemporaryDeleted.Any(h => h.Name == hardware))
        {
            foreach (var hard in this.TemporaryDeleted)
            {
                if (hard.Name == hardware)
                {
                    hardwares[hardware] = hard;
                    break;
                }
            }
        }
    }

    public void Destroy(string hardware)
    {
        if (this.TemporaryDeleted.Any(t => t.Name == hardware))
        {
            for (int i = 0; i < this.TemporaryDeleted.Count; i++)
            {
                if (this.TemporaryDeleted[i].Name == hardware)
                {
                    this.TemporaryDeleted.RemoveAt(i);
                    break;
                }
            }
        }
    }
    
    public string Analyze()
    {
        int powerHardwareComponents = this.TemporaryDeleted.Where(h => h.Type == "Power").Count();
        int heavyHardwareComponents = this.TemporaryDeleted.Where(h => h.Type == "Heavy").Count();
        int expressSoftwareComponents = this.TemporaryDeleted.Sum(h => h.SoftwareComponents.Where(s => s.Type == "ExpressSoftware").Count());
        int lightSoftwareComponents = this.TemporaryDeleted.Sum(h => h.SoftwareComponents.Where(s => s.Type == "LightSoftware").Count());
        int totalDumpedMemory = this.TemporaryDeleted.Sum(h => h.SoftwareComponents.Sum(s => s.MemoryConsumption));
        int totalDumpedCapacity = this.TemporaryDeleted.Sum(h => h.SoftwareComponents.Sum(s => s.CapacityConsumption));

        return $"Dump Analysis\r\n" +
               $"Power Hardware Components: {powerHardwareComponents}\r\n" +
               $"Heavy Hardware Components: {heavyHardwareComponents}\r\n" +
               $"Express Software Components: {expressSoftwareComponents}\r\n" +
               $"Light Software Components: {lightSoftwareComponents}\r\n" +
               $"Total Dumped Memory: {totalDumpedMemory}\r\n" +
               $"Total Dumped Capacity: {totalDumpedCapacity}";
    }
}
