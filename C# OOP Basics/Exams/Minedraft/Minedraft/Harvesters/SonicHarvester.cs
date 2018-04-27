using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor;
    
    public SonicHarvester(string id, double oreOutput, double energy, int sonicFactor) 
        : base(id, oreOutput, energy)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        private set { sonicFactor = value; }
    }

    public override string ToString()
    {
        return $"Sonic Harvester - {this.Id}\r\n" +
               $"Ore Output: {this.OreOutput}\r\n" +
               $"Energy Requirement: {this.EnergyRequirement}";
    }
}
