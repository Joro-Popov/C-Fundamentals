public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public virtual double Speed => (this.Car.HP + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public abstract double FuelConsumptionPerKM { get; }

    public Car Car
    {
        get { return car; }
        private set { car = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        private set { totalTime = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public void IncreaseTotalTime(int time)
    {
        this.TotalTime += time;
    }

    public void IncreaseTotalTimeInRace(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    public void ReduceTotalTime(int time)
    {
        this.TotalTime -= time;
    }
}