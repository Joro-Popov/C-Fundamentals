public abstract class Bender : IBender
{
    protected Bender(string name, long power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get; private set; }

    public long Power { get; private set; }

    public override string ToString()
    {
        return $"{this.Name}, Power: {this.Power},";
    }

    public abstract double GetPower();
}