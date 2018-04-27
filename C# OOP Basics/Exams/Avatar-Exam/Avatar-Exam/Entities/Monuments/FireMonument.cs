public class FireMonument : Monument
{
    private long fireAffinity;

    public  FireMonument(string name, long fireAffinity) : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public long FireAffinity
    {
        get { return fireAffinity; }
        private set { fireAffinity = value; }
    }

    public override long Affinity => this.FireAffinity;

    public override string ToString()
    {
        return $"Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}";
    }
}