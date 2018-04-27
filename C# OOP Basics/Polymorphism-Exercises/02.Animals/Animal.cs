public abstract class Animal
{
    private string name;
    private string favouriteFood;

    public Animal(string name, string food)
    {
        this.Name = name;
        this.FavouriteFood = food;
    }

    public string FavouriteFood
    {
        get { return favouriteFood; }
        set { favouriteFood = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public virtual string ExplainSelf()
    {
        return $"I am {this.name} and my favourite food is {this.FavouriteFood}";
    }
}