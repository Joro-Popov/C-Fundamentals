using System;

public class InfinityHarvester : Harvester
{
    private const double OreOutputDivider = 10.0;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }

    public override double Durability
    {
        get => this.durability;
        protected set => this.durability = Math.Max(0, value);
    }
}