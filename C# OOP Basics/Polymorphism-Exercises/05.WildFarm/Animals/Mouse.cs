public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    {
        this.EatableFoods.Add("Vegetable");
        this.EatableFoods.Add("Fruit");
    }

    public override string ProduceSound()
    {
        return "Squeak";
    }

    public override void Feed(Food food)
    {
        base.Feed(food);
        this.Weight += food.Quantity * 0.10;
    }
}