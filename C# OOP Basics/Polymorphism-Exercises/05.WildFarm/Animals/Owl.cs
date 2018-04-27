public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
        this.EatableFoods.Add("Meat");
    }

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }

    public override void Feed(Food food)
    {
        base.Feed(food);
        this.Weight += food.Quantity * 0.25;
    }
}