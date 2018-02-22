using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static bool IsEmpty(Dictionary<int,HashSet<int>> parkingLot, int spotRow, int spotCol)
    {
        if (parkingLot.ContainsKey(spotRow))
        {
            if (parkingLot[spotRow].Contains(spotCol))
            {
                return false;
            }  
        }
        else
        {
            parkingLot[spotRow] = new HashSet<int>();
        }
        return true;
    }
    public static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        string command = Console.ReadLine();

        Dictionary<int, HashSet<int>> parkingLot = new Dictionary<int, HashSet<int>>();

        while (command != "stop")
        {
            int[] arguments = command.Split(' ').Select(int.Parse).ToArray();

            int entryRow = arguments[0];
            int spotRow = arguments[1];
            int spotCol = arguments[2];

            int parkCol = 0;

            if (IsEmpty(parkingLot,spotRow,spotCol))
            {
                parkCol = spotCol;
            }
            else
            {
                for (int i = 1; i < cols - 1; i++)
                {
                    if (((spotCol - i) > 0) && IsEmpty(parkingLot, spotRow, (spotCol - i)))
                    {
                        parkCol = spotCol - i;
                        break;
                    }
                    else if (((spotCol + i) < cols) && IsEmpty(parkingLot, spotRow, (spotCol + i)))
                    {
                        parkCol = spotCol + i;
                        break;
                    }
                }
            }

            if (parkCol == 0)
            {
                Console.WriteLine($"Row {spotRow} full");
            }
            else
            {
                parkingLot[spotRow].Add(parkCol);
                int distance = parkCol + Math.Abs((spotRow - entryRow)) + 1;
                Console.WriteLine(distance);
            }
            command = Console.ReadLine();
        }
    }
    
}
