using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private CarManager manager;

    public Engine()
    {
        this.Manager = new CarManager();
    }

    public void Run()
    {
        string input;

        while ((input = Console.ReadLine()) != "Cops Are Here")
        {
            List<string> args = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string cmd = args[0];
            args.RemoveAt(0);

            switch (cmd)
            {
                case "register":
                    var id = int.Parse(args[0]);
                    var type = args[1];
                    var brand = args[2];
                    var model = args[3];
                    var year = int.Parse(args[4]);
                    var hp = int.Parse(args[5]);
                    var acceleration = int.Parse(args[6]);
                    var suspension = int.Parse(args[7]);
                    var durability = int.Parse(args[8]);

                    this.Manager.Register(id, type, brand, model, year, hp, acceleration, suspension, durability);
                    break;

                case "check":
                    var checkId = int.Parse(args[0]);
                    Console.WriteLine(this.Manager.Check(checkId));
                    break;

                case "open":
                    var raceId = int.Parse(args[0]);
                    var raceType = args[1];
                    var length = int.Parse(args[2]);
                    var route = args[3];
                    var prizePool = int.Parse(args[4]);

                    if (args.Count == 6)
                    {
                        var param = int.Parse(args[5]);
                        this.Manager.Open(raceId, raceType, length, route, prizePool,param);
                    }
                    else
                    {
                        this.Manager.Open(raceId, raceType, length, route, prizePool);
                    }
                    break;

                case "participate":
                    var carId = int.Parse(args[0]);
                    var raceID = int.Parse(args[1]);
                    this.Manager.Participate(carId, raceID);
                    break;

                case "start":
                    try
                    {
                        var startId = int.Parse(args[0]);
                        Console.WriteLine(this.Manager.Start(startId));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "park":
                    var parkId = int.Parse(args[0]);
                    this.Manager.Park(parkId); break;

                case "unpark":
                    var unparkId = int.Parse(args[0]);
                    this.Manager.Unpark(unparkId); break;

                case "tune":
                    var tuneIndex = int.Parse(args[0]);
                    var tuneAddOn = args[1];
                    this.Manager.Tune(tuneIndex, tuneAddOn);
                    break;
            }
        }
    }

    public CarManager Manager
    {
        get { return manager; }
        private set { manager = value; }
    }
}
