public class SolarProvider : Provider
{
    private const double DurabilityIncreasement = 500.0;

    public SolarProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability += DurabilityIncreasement;
    }
}