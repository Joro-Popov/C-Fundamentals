public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    {
        this.EatableFoods.Add("Meat");
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }

    public override void Feed(Food food)
    {
        base.Feed(food);
        this.Weight += food.Quantity * 0.40;
    }
}