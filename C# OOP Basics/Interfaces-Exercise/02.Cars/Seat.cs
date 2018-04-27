public class Seat : Car
{
    public Seat(string model, string color) : base(model, color)
    {
        this.Model = model;
        this.Color = color;
    }

    public override string ToString()
    {
        return $"{this.Color} {this.GetType().Name} {this.Model}\r\n" +
               $"{this.Start()}\r\n" +
               $"{this.Stop()}";
    }
}