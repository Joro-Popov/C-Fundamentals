public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, long power, double aerialIntegrity) : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }
    
    public double AerialIntegrity
    {
        get { return aerialIntegrity; }
        private set { aerialIntegrity = value; }
    }

    public override double GetPower()
    {
        return this.Power * this.AerialIntegrity;
    }

    public override string ToString()
    {
        return $"Air Bender: {base.ToString()} Aerial Integrity: {this.AerialIntegrity:f2}";
    }
}