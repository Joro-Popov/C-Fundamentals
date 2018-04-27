public class WaterMonument : Monument
{
    private long waterAffinity;

    public WaterMonument(string name, long waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public long WaterAffinity
    {
        get { return waterAffinity; }
        private set { waterAffinity = value; }
    }

    public override long Affinity => this.WaterAffinity;

    public override string ToString()
    {
        return $"Water Monument: {this.Name}, Water Affinity: {this.WaterAffinity}";
    }
}