public abstract class Item : IItem
{
    protected Item(int weight)
    {
        this.Weight = weight;
    }

    public int Weight { get; private set; }

    public abstract void AffectCharacter(Character character);
}