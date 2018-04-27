using System;
using System.Collections.Generic;
using System.Linq;
public class Startup
{
    static void Main()
    {
        IAddCollection<string> AddCollection = new MyList<string>();
        IAddRemoveCollection<string> AddRemoveCollection = new MyList<string>();
        IMyList<string> MyListCollection = new MyList<string>();

        List<string> input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        
        int removeOperations = int.Parse(Console.ReadLine());

        IAddCollection<int> AddCollectionIndexes = new MyList<int>();
        IAddRemoveCollection<int> AddRemoveCollectionIndexes = new MyList<int>();
        IMyList<int> MyListCollectionIndexes = new MyList<int>();
        IAddRemoveCollection<string> AddRemoveCollectionItems = new MyList<string>();
        IMyList<string> MyListCollectionItems = new MyList<string>();

        foreach (var item in input)
        {
            AddCollectionIndexes.AddToEnd(AddCollection.AddToEnd(item));
            AddRemoveCollectionIndexes.AddToStart(AddRemoveCollection.AddToStart(item));
            MyListCollectionIndexes.AddToStart(MyListCollection.AddToStart(item));
        }
        for (int count = 0; count < removeOperations; count++)
        {
            AddRemoveCollectionItems.AddToEnd(AddRemoveCollection.RemoveLast());
            MyListCollectionItems.AddToEnd(MyListCollection.RemoveFirst());
        }
        
        Console.WriteLine(string.Join(" ", AddCollectionIndexes));
        Console.WriteLine(string.Join(" ", AddRemoveCollectionIndexes));
        Console.WriteLine(string.Join(" ", MyListCollectionIndexes));
        Console.WriteLine(string.Join(" ", AddRemoveCollectionItems));
        Console.WriteLine(string.Join(" ", MyListCollectionItems));
    }
    
}
