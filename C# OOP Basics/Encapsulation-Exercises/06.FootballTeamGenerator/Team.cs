using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private List<Player> players;
    private string name;
    private double rating;

    public double Rating
    {
        get { return rating; }
        private set { rating = value; }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public List<Player> Players
    {
        get { return players; }
        private set { players = value; }
    }

    public Team(string name)
    {
        Name = name;
        Players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }

    public void RemovePlayer(string player)
    {
        for (int count = 0; count < players.Count; count++)
        {
            if (players[count].Name == player)
            {
                players.RemoveAt(count);
                break;
            }
        }
    }

    public override string ToString()
    {
        double rating = players.Sum(p => p.Stats.SkillLevel / players.Count);
        return $"{Name} - {Math.Round(rating, 0)}";
    }
}