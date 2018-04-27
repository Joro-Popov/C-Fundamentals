public class FireBender : Bender
{
    private double heatAggression;

    public FireBender(string name, long power, double heatAggression) : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }
    
    public double HeatAggression
    {
        get { return heatAggression; }
        private set { heatAggression = value; }
    }

    public override double GetPower()
    {
        return this.Power * this.HeatAggression;
    }

    public override string ToString()
    {
        return $"Fire Bender: {base.ToString()} Heat Aggression: {this.HeatAggression:f2}";
    }
}