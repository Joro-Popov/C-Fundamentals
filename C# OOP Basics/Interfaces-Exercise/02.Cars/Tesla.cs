public class Tesla : Car, IElectricCar
{
    private int battery;

    public Tesla(string model, string color, int battery)
        : base(model, color)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public int Battery
    {
        get { return this.battery; }
        private set { this.battery = value; }
    }

    public override string ToString()
    {
        return $"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries\r\n" +
               $"{this.Start()}\r\n" +
               $"{this.Stop()}";
    }
}