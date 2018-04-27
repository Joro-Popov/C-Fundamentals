public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
        this.EatableFoods.Add("Vegetable");
        this.EatableFoods.Add("Fruit");
        this.EatableFoods.Add("Meat");
        this.EatableFoods.Add("Seeds");
    }

    public override string ProduceSound()
    {
        return "Cluck";
    }

    public override void Feed(Food food)
    {
        base.Feed(food);
        this.Weight += food.Quantity * 0.35;
    }
}