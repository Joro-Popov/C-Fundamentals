using System;

public class Circle : IDrawable
{
    private int radius;

    public Circle(int radius)
    {
        this.Radius = radius;
    }

    public int Radius
    {
        get { return radius; }
        private set { radius = value; }
    }

    public void Draw()
    {
        double rIn = this.Radius - 0.4;
        double rout = this.Radius + 0.4;

        for (double y = this.Radius; y >= -this.Radius; --y)
        {
            for (double x = -this.Radius; x < rout; x += 0.5)
            {
                double value = x * x + y * y;

                if (value >= rIn * rIn && value <= rout * rout)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}