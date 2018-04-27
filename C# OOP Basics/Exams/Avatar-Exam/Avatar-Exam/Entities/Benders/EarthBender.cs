public class EarthBender : Bender
{
    private double groundSaturation;

    public EarthBender(string name, long power, double groundSaturation) : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }
    
    public double GroundSaturation
    {
        get { return groundSaturation; }
        private set { groundSaturation = value; }
    }

    public override double GetPower()
    {
        return this.Power * this.GroundSaturation;
    }

    public override string ToString()
    {
        return $"Earth Bender: {base.ToString()} Ground Saturation: {this.GroundSaturation:f2}";
    }
}