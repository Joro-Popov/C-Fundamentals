using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine()
    {
        this.RaceTower = new RaceTower();
    }

    public RaceTower RaceTower
    {
        get { return raceTower; }
        private set { raceTower = value; }
    }

    public void Run()
    {
        int numberOfLaps = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());
        this.RaceTower.SetTrackInfo(numberOfLaps, trackLength);

        while (!RaceTower.HasWinner)
        {
            List<string> args = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = args[0];
            args.RemoveAt(0);

            switch (command)
            {
                case "RegisterDriver":
                    this.RaceTower.RegisterDriver(args); break;

                case "Leaderboard":
                    Console.WriteLine(this.RaceTower.GetLeaderboard());
                    break;

                case "CompleteLaps":
                    var result = this.RaceTower.CompleteLaps(args);

                    if (result != string.Empty)
                    {
                        Console.WriteLine(result);
                    }
                    break;

                case "Box":
                    this.RaceTower.DriverBoxes(args); break;

                case "ChangeWeather":
                    this.RaceTower.ChangeWeather(args); break;
            }
        }
        Console.WriteLine($"{this.RaceTower.Winner.Name} wins the race for {this.RaceTower.Winner.TotalTime:f3} seconds.");
    }
}