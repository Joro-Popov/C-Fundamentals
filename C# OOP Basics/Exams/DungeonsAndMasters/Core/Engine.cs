using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DungeonMaster dungeonMaster;

    public Engine(DungeonMaster dungeonMaster)
    {
        this.dungeonMaster = dungeonMaster;
    }

    public void Run()
    {
        string command = Console.ReadLine();

        while (true)
        {
            if (string.IsNullOrEmpty(command) || string.IsNullOrWhiteSpace(command))
            {
                break;
            }

            var args = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var cmd = args[0];
            args = args.Skip(1).ToArray();

            try
            {
                switch (cmd)
                {
                    case "JoinParty": Console.WriteLine(this.dungeonMaster.JoinParty(args)); break;
                    case "AddItemToPool": Console.WriteLine(this.dungeonMaster.AddItemToPool(args)); break;
                    case "PickUpItem": Console.WriteLine(this.dungeonMaster.PickUpItem(args)); break;
                    case "UseItem": Console.WriteLine(this.dungeonMaster.UseItem(args)); break;
                    case "UseItemOn": Console.WriteLine(this.dungeonMaster.UseItemOn(args)); break;
                    case "GiveCharacterItem": Console.WriteLine(this.dungeonMaster.GiveCharacterItem(args)); break;
                    case "GetStats": Console.WriteLine(this.dungeonMaster.GetStats()); break;
                    case "Attack": Console.WriteLine(this.dungeonMaster.Attack(args)); break;
                    case "Heal": Console.WriteLine(this.dungeonMaster.Heal(args)); break;
                    case "EndTurn": Console.WriteLine(this.dungeonMaster.EndTurn(args)); break;
                    case "IsGameOver": Console.WriteLine(this.dungeonMaster.IsGameOver()); break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(string.Format(Constants.ArgumentExceptionMessage, ex.Message));
                
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(string.Format(Constants.InvalidOperationExceptionMessage, ex.Message));
            }

            if (this.dungeonMaster.IsGameOver())
            {
                break;
            }

            command = Console.ReadLine();
        }

        Console.WriteLine("Final stats:");
        Console.WriteLine(this.dungeonMaster.GetStats());
    }
}