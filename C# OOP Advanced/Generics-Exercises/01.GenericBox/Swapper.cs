using System;
using System.Collections.Generic;
using System.Text;

public class Swapper
{
    public static void Swap<T>(IList<T> items, int index1, int index2)
    {
        if (IsInRange(items.Count - 1, index1) && IsInRange(items.Count - 1, index2))
        {
            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }
    }

    private static bool IsInRange(int count, int index)
    {
        if (index >= 0 && index <= count)
        {
            return true;
        }
        return false;
    }
}
