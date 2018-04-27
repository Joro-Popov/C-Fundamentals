public class HardTyre : Tyre
{
    private const string HARD_NAME = "Hard";

    public HardTyre(double tyreHardness)
        : base(tyreHardness)
    {
    }

    public override string Name => HARD_NAME;
}