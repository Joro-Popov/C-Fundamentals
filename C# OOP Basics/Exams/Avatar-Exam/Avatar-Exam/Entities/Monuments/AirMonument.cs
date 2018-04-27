public class AirMonument : Monument
{
    private long airAffinity;

    public  AirMonument(string name, long affinity) : base(name)
    {
        this.AirAffinity = affinity;
    }

    public long AirAffinity
    {
        get { return airAffinity; }
        private set { airAffinity = value; }
    }

    public override long Affinity => this.AirAffinity;

    public override string ToString()
    {
        return $"Air Monument: {this.Name}, Air Affinity: {this.AirAffinity}";
    }
}