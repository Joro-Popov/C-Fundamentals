public class Ferrari : ICar
{
    private string model = "488-Spider";
    private string driver;

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string Driver
    {
        get { return driver; }
        private set { driver = value; }
    }

    public string PushBrake()
    {
        return $"Brakes!";
    }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.model}/{this.PushBrake()}/{this.PushGas()}/{this.Driver}";
    }
}