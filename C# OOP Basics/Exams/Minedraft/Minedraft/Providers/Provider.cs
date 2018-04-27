using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : IProvider
{
    private const string REG_ERROR = "Provider is not registered, because of it's {0}";

    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException(string.Format(REG_ERROR,"EnergyOutput"));
            }
            energyOutput = value;
        }
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
    }

}
