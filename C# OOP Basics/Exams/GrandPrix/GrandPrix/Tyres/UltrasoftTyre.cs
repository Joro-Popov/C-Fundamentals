using System;

public class UltrasoftTyre : Tyre
{
    private const string ULTRASOFT_NAME = "Ultrasoft";
    private double grip;

    public UltrasoftTyre(double tyreHardness, double grip)
        : base(tyreHardness)
    {
        this.Grip = grip;
    }

    public double Grip
    {
        get { return grip; }
        private set { grip = value; }
    }

    public override string Name => ULTRASOFT_NAME;

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException(OutputMessages.BlownTyre);
            }
            base.Degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        this.Degradation -= (this.Hardness + this.Grip);
    }
}