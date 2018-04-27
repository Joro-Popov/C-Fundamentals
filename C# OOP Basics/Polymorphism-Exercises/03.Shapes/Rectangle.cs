public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double h, double w)
    {
        this.Height = h;
        this.Width = w;
    }

    public double Width
    {
        get { return width; }
        private set { width = value; }
    }

    public double Height
    {
        get { return height; }
        private set { height = value; }
    }

    public override double CalculateArea()
    {
        double area = this.Width * this.Height;
        return area;
    }

    public override double CalculatePerimeter()
    {
        double perimeter = 2 * this.Width + 2 * this.Height;
        return perimeter;
    }

    public override string Draw()
    {
        return $"{base.Draw()}Rectangle";
    }
}