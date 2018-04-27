using System;
using System.Collections.Generic;
using System.Text;

public class Figure
{
    public int SideA { get; set; }
    public int SideB { get; set; }
    
    public Figure(int sideA,int sideB)
    {
        SideA = sideA;
        SideB = sideB;
    }
    public void Draw()
    {
        Console.WriteLine($"|{new string('-',SideA)}|");
        for (int count = 0; count < SideB - 2; count++)
        {
            Console.WriteLine($"|{new string(' ', SideA)}|");
        }
        Console.WriteLine($"|{new string('-', SideA)}|");
    }
}

