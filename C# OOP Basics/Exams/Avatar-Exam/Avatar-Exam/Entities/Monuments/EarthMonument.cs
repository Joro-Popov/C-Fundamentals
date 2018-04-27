public class EarthMonument : Monument
{
    private long earthAffinity;

    public  EarthMonument(string name, long earthAffinity) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }
    
    public long EarthAffinity
    {
        get { return earthAffinity; }
        private set { earthAffinity = value; }
    }

    public override long Affinity => this.EarthAffinity;

    public override string ToString()
    {
        return $"Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffinity}";
    }
}