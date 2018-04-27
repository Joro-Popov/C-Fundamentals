using System.Collections.Generic;
using System.Linq;
using System;

public abstract class Bag : IBag
{
    private readonly List<Item> items;

    protected Bag(int capacity = 100)
    {
        this.Capacity = capacity;
        this.items = new List<Item>();
    }

    public int Capacity { get; private set; }

    public int Load => this.items.Sum(i => i.Weight);

    public IReadOnlyCollection<Item> Items => this.items;

    public void AddItem(Item item)
    {
        if (this.Load + item.Weight <= this.Capacity)
        {
            this.items.Add(item);
        }
        else
        {
            throw new InvalidOperationException(Constants.FullBag);
        }
    }

    public Item GetItem(string name)
    {
        bool BagIsNotEmpty = this.items.Any();
        bool ItemDoesExist = this.items.FirstOrDefault(i => i.GetType().Name == name) != null;

        if (!BagIsNotEmpty)
        {
            throw new InvalidOperationException(Constants.EmptyBag);
        }
        else if (!ItemDoesExist)
        {
            throw new ArgumentException(string.Format(Constants.NonExistingItem,name));
        }
        else
        {
            var item = this.items.FirstOrDefault(i => i.GetType().Name == name);

            this.items.Remove(item);

            return item;
        }
    }
}