using System;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        string command;

        while ((command = Console.ReadLine()) != "Quit")
        {
            var args = command.Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries).ToList();

            var cmd = args[0];

            args = args.Skip(1).ToList();

            switch (cmd)
            {
                case "Bender": this.nationsBuilder.AssignBender(args); break;

                case "Monument": this.nationsBuilder.AssignMonument(args); break;

                case "Status":
                    var nationsType = args[0];
                    Console.WriteLine(this.nationsBuilder.GetStatus(nationsType));
                    break;

                case "War":
                    var nation = args[0];
                    this.nationsBuilder.IssueWar(nation);
                    break;

            }
        }

        string result = this.nationsBuilder.GetWarsRecord();

        Console.WriteLine(result);
    }
}