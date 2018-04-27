public abstract class Feline : Mammal
{
    private string breed;

    public Feline(string name, double weight, string livingRegion, string breed)
       : base(name, weight, livingRegion)
    {
        this.Breed = breed;
        this.EatableFoods.Add("Meat");
    }

    public string Breed
    {
        get { return breed; }
        private set { breed = value; }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}