using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : IHarvester
{
    private const string REG_ERROR = "Harvester is not registered, because of it's {0}";
    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energy)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energy;
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value > 20000)
            {
                throw new ArgumentException(string.Format(REG_ERROR,"EnergyRequirement"));
            }
            energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(REG_ERROR,"OreOutput"));
            }
            oreOutput = value;
        }
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
    }

}
