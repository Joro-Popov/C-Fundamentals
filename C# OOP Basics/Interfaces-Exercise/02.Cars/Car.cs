public abstract class Car : ICar
{
    private string model;
    private string color;

    public Car(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }
}