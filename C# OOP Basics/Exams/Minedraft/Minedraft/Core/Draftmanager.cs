using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private double totalStoredEnergy;
    private double totalMineOre;
    private string systemMode;
    private double summedEnergyOutput;
    private double summedOreOutput;

    public DraftManager()
    {
        this.Harvesters = new Dictionary<string, Harvester>();
        this.Providers = new Dictionary<string, Provider>();
        this.totalStoredEnergy = 0;
        this.totalMineOre = 0;
        this.summedEnergyOutput = 0;
        this.summedOreOutput = 0;
        this.SystemMode = "Full";
    }

    public string SystemMode
    {
        get { return systemMode; }
        private set { systemMode = value; }
    }

    public Dictionary<string, Provider> Providers
    {
        get { return providers; }
        private set { providers = value; }
    }

    public Dictionary<string, Harvester> Harvesters
    {
        get { return harvesters; }
        private set { harvesters = value; }
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = HarvesterFactory.CreateHarvest(arguments);
            this.Harvesters[arguments[1]] = harvester;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = ProviderFactory.CreateProvider(arguments);
            this.Providers[arguments[1]] = provider;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }

    public string Day()
    {
        this.totalStoredEnergy += this.Providers.Values.Sum(p => p.EnergyOutput);
        double totalEnergyRequirement = this.Harvesters.Values.Sum(h => h.EnergyRequirement);
        this.summedEnergyOutput = this.Providers.Values.Sum(p => p.EnergyOutput);

        if (totalStoredEnergy >= totalEnergyRequirement)
        {
            switch (this.SystemMode)
            {
                case "Full":
                    this.totalStoredEnergy -= this.Harvesters.Values.Sum(h => h.EnergyRequirement);
                    this.totalMineOre += this.Harvesters.Values.Sum(h => h.OreOutput);
                    this.summedOreOutput = this.Harvesters.Values.Sum(h => h.OreOutput);
                    break;

                case "Half":
                    this.totalStoredEnergy -= this.Harvesters.Values.Sum(h => (h.EnergyRequirement * 60) / 100);
                    this.totalMineOre += this.Harvesters.Values.Sum(h => (h.OreOutput * 50) / 100);
                    this.summedOreOutput = this.Harvesters.Values.Sum(h => (h.OreOutput * 50) / 100);
                    break;

                case "Energy": break;
            }
        }
        return $"A day has passed.\r\n" +
               $"Energy Provided: {this.summedEnergyOutput}\r\n" +
               $"Plumbus Ore Mined: {this.summedOreOutput}";
    }

    public string Mode(List<string> arguments)
    {
        string ChangingMode = arguments[0];
        this.SystemMode = ChangingMode;
        return $"Successfully changed working mode to {ChangingMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (this.Harvesters.ContainsKey(id))
        {
            return this.Harvesters[id].ToString();
        }
        else if (this.Providers.ContainsKey(id))
        {
            return this.Providers[id].ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        return $"System Shutdown\r\n" +
               $"Total Energy Stored: {this.totalStoredEnergy}\r\n" +
               $"Total Mined Plumbus Ore: {this.totalMineOre}";
    }
}
