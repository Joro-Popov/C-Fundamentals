using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        List<Soldier> allSoldiers = new List<Soldier>();
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            Queue<string> info = new Queue<string>(command
                .Split(' ')
                .ToList());

            Soldier soldier = GetSoldier(info, allSoldiers);
            if (soldier != null)
            {
                allSoldiers.Add(soldier);
            }
        }
        foreach (var soldier in allSoldiers)
        {
            Console.WriteLine(soldier);
        }
    }
    private static Soldier GetSoldier(IEnumerable<string> info,List<Soldier>allSoldiers)
    {
        Queue<string> infoAsQueue = new Queue<string>(info);
        Soldier current = null;

        switch (infoAsQueue.Dequeue())
        {
            case "Private":
                current = new Private(infoAsQueue.Dequeue(),
                                   infoAsQueue.Dequeue(),
                                   infoAsQueue.Dequeue(),
                                   double.Parse(infoAsQueue.Dequeue()));break;

            case "LeutenantGeneral":
                current = new LeutenantGeneral(infoAsQueue.Dequeue(),
                                            infoAsQueue.Dequeue(),
                                            infoAsQueue.Dequeue(),
                                            double.Parse(infoAsQueue.Dequeue()),
                                            GetPrivates(allSoldiers,infoAsQueue));break;

            case "Engineer":
                if (!((infoAsQueue as IList<string>)[5] == "Airforces" || (infoAsQueue as IList<string>)[5] == "Marines"))
                {
                    break;
                }
                current = new Engineer(infoAsQueue.Dequeue(),
                                    infoAsQueue.Dequeue(),
                                    infoAsQueue.Dequeue(),
                                    double.Parse(infoAsQueue.Dequeue()),
                                    infoAsQueue.Dequeue(),
                                    GetRepairs(infoAsQueue));break;

            case "Commando":
                if (!(infoAsQueue.Last() == "AirForces" || infoAsQueue.Last() == "Marines"))
                {
                    break;
                }
                current = new Commando(infoAsQueue.Dequeue(),
                                    infoAsQueue.Dequeue(),
                                    infoAsQueue.Dequeue(),
                                    double.Parse(infoAsQueue.Dequeue()),
                                    infoAsQueue.Dequeue(),
                                    GetMissions(infoAsQueue));break;

            case "Spy":
                current = new Spy(infoAsQueue.Dequeue(),
                               infoAsQueue.Dequeue(),
                               infoAsQueue.Dequeue(),
                               int.Parse(infoAsQueue.Dequeue()));break;
            
        }
        return current;
    }

    private static IEnumerable<IPrivate> GetPrivates(IEnumerable<Soldier> allSoldiers,IEnumerable<string> info)
    {
        List<IPrivate> privates = new List<IPrivate>();

        foreach (var soldier in info)
        {
            var soldierById = allSoldiers.SingleOrDefault(s => s.ID == soldier);
            privates.Add(soldierById as IPrivate);
           
        }
        return privates;
    }

    private static IEnumerable<IRepair> GetRepairs(Queue<string> info)
    {
        List<IRepair> repaired = new List<IRepair>();
        int count = info.Count();

        for (int counter = 0; counter < count; counter+= 2)
        {
            IRepair current = new Repair(info.Dequeue(), int.Parse(info.Dequeue()));
            repaired.Add(current);
        }
        
        return repaired;
    }

    private static IEnumerable<IMission> GetMissions(Queue<string> info)
    {
        List<IMission> missions = new List<IMission>();
        int count = info.Count();

        for (int counter = 0; counter < count; counter += 2)
        {
            IMission current = new Mission(info.Dequeue(), info.Dequeue());

            if (current.State == "Finished" || current.State == "inProgress")
            {
                missions.Add(current);
            }
        }
        return missions;
    }
}
