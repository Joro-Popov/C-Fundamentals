using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(List<int>coords)
    {
        TopLeft = new Point(coords[0], coords[1]);
        BottomRight = new Point(coords[2], coords[3]);
    }
    public bool ContainsPoint(Point point)
    {
        if ((point.X >= TopLeft.X && point.X <= BottomRight.X) && 
            (point.Y >= TopLeft.Y && point.Y <= BottomRight.Y))
        {
            return true;
        }
        return false;
    }
}
