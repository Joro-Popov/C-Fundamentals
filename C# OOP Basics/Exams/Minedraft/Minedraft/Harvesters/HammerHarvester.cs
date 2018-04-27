using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energy) 
        : base(id, oreOutput, energy)
    {
        this.OreOutput += (this.OreOutput * 200) / 100;
        this.EnergyRequirement += this.EnergyRequirement;
    }

    public override string ToString()
    {
        return $"Hammer Harvester - {this.Id}\r\n" +
               $"Ore Output: {this.OreOutput}\r\n" +
               $"Energy Requirement: {this.EnergyRequirement}";
    }
}
