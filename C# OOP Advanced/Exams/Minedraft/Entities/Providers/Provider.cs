using System;

public abstract class Provider : IProvider
{
    private const double InitialDurability = 1000.0;
    private const double LooseDurability = 100.0;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; private set; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= LooseDurability;

        if (this.Durability < 0)
        {
            throw new ArgumentException();
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}