using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private IEnergyRepository energyRepository;
    private List<IHarvester> harvesters;
    private IHarvesterFactory factory;
    private Mode mode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.factory = new HarvesterFactory();
        this.mode = Mode.Full;
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        Enum.TryParse(mode, out Mode newMode);
        this.mode = newMode;

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        var result = string.Format(Constants.ModeChange, mode);

        return result;
    }

    public string Produce()
    {
        var totalNeededEnergy = this.harvesters.Sum(h => h.EnergyRequirement * (int)mode / 100);

        var oreProducedToday = 0d;

        if (this.energyRepository.TakeEnergy(totalNeededEnergy))
        {
            foreach (var harvester in this.harvesters)
            {
                oreProducedToday += harvester.Produce() * (int)mode / 100;
            }
            this.OreProduced += oreProducedToday;
        }

        return string.Format(Constants.OreOutputToday, oreProducedToday);
    }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);

        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}