public class Box
{
    private double length;
    private double width;
    private double height;

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public double Length
    {
        get { return length; }
        set { length = value; }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double GetSurfaceArea()
    {
        double area = 2 * (width * height) + 2 * (height * length) + 2 * (width * length);
        return area;
    }

    public double GetLateralSurfaceArea()
    {
        double lateralArea = 2 * (length * height) + 2 * (width * height);
        return lateralArea;
    }

    public double GetVolume()
    {
        double volume = width * height * length;
        return volume;
    }
}