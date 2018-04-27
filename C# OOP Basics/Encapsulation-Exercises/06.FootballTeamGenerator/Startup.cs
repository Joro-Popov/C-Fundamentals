using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void AddPlayer(Dictionary<string, Team> teams, Queue<string> info)
    {
        string team = info.Dequeue();
        if (teams.ContainsKey(team))
        {
            Player player = new Player(info);
            teams[team].AddPlayer(player);
        }
        else
        {
            throw new ArgumentException($"Team {team} does not exist.");
        }
    }

    public static void RemovePlayer(Dictionary<string, Team> teams, Queue<string> info)
    {
        string team = info.Dequeue();
        string name = info.Dequeue();

        if (teams.Values.Any(t => t.Players.Any(p => p.Name == name)))
        {
            teams[team].RemovePlayer(name);
        }
        else
        {
            throw new ArgumentException($"Player {name} is not in {team} team.");
        }
    }

    public static void PrintRating(Dictionary<string, Team> teams, Queue<string> info)
    {
        string team = info.Dequeue();
        if (teams.ContainsKey(team))
        {
            Console.WriteLine(teams[team]);
        }
        else
        {
            throw new ArgumentException($"Team {team} does not exist.");
        }
    }

    private static void Main()
    {
        var teams = new Dictionary<string, Team>();
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            Queue<string> info = new Queue<string>(command.
                Split(';', StringSplitOptions.RemoveEmptyEntries));

            switch (info.Dequeue())
            {
                case "Team": teams[info.Peek()] = new Team(info.Dequeue()); break;
                case "Add":
                    try
                    {
                        AddPlayer(teams, info);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "Remove":
                    try
                    {
                        RemovePlayer(teams, info);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "Rating":
                    try
                    {
                        PrintRating(teams, info);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }
        }
    }
}