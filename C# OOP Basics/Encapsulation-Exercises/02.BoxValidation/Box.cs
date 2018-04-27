using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
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