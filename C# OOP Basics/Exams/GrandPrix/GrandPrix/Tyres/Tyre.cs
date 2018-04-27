using System;

public abstract class Tyre
{
    private const double INIT_DEGRADATION = 100;

    private double hardness;
    private double degradation;

    protected Tyre(double tyreHardness)
    {
        this.Hardness = tyreHardness;
        this.Degradation = INIT_DEGRADATION;
    }

    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(OutputMessages.BlownTyre);
            }
            degradation = value;
        }
    }

    public double Hardness
    {
        get { return hardness; }
        private set { hardness = value; }
    }

    public abstract string Name { get; }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}