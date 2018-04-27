using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        Rectangle rectangle = new Rectangle(Console.ReadLine().Split().Select(int.Parse).ToList());
        int counter = int.Parse(Console.ReadLine());
        for (int index = 0; index < counter; index++)
        {
            List<int> pointCoords = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            Point point = new Point(pointCoords[0], pointCoords[1]);
            Console.WriteLine(rectangle.ContainsPoint(point));
        }
    }
}
