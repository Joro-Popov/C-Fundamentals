public abstract class Monument : IMonument
{
    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public abstract long Affinity { get; }
}