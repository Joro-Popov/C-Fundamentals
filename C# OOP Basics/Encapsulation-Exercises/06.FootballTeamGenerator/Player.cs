using System;
using System.Collections.Generic;

public class Player
{
    private string name;
    private Stats stats;

    public Player(Queue<string> info)
    {
        Name = info.Dequeue();
        stats = new Stats(info);
    }

    public Stats Stats
    {
        get { return stats; }
        private set { stats = value; }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty");
            }
            name = value;
        }
    }
}