public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
    }

    public override string ProduceSound()
    {
        return "ROAR!!!";
    }

    public override void Feed(Food food)
    {
        base.Feed(food);
        this.Weight += food.Quantity * 1.00;
    }
}