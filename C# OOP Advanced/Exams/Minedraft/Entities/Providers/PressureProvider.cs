public class PressureProvider : Provider
{
    private const double DurabilityDecreasement = 300;
    private const int EnergyMultiplier = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability -= DurabilityDecreasement;
        this.EnergyOutput *= EnergyMultiplier;
    }
}