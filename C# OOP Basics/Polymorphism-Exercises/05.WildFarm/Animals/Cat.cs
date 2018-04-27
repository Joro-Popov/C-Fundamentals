public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
        this.EatableFoods.Add("Vegetable");
    }

    public override string ProduceSound()
    {
        return "Meow";
    }

    public override void Feed(Food food)
    {
        base.Feed(food);
        this.Weight += food.Quantity * 0.30;
    }
}