using System;
using System.Collections.Generic;

public class ControlSystem
{
    private ICollection<IIdentifiable> citizens;
    private ICollection<IBirthable> livingBeing;
    private IDictionary<string,Person> buyers;
    
    private List<string> detainedIds;

    public ControlSystem()
    {
        this.Citizens = new List<IIdentifiable>();
        this.livingBeing = new List<IBirthable>();
        this.Buyers = new Dictionary<string, Person>();
        this.detainedIds = new List<string>();
    }

    public IDictionary<string, Person> Buyers
    {
        get { return buyers; }
        set { buyers = value; }
    }

    public ICollection<IBirthable> LivingBeings
    {
        get { return livingBeing; }
        private set { livingBeing = value; }
    }

    public ICollection<IIdentifiable> Citizens
    {
        get { return citizens; }
        private set { citizens = value; }
    }

    public void GetDetainedIds(string detainedId)
    {
        foreach (var item in this.citizens)
        {
            if (item.Id.EndsWith(detainedId))
            {
                this.detainedIds.Add(item.Id);
            }
        }
    }
    
    public void PrintDetained()
    {
        foreach (var detained in this.detainedIds)
        {
            Console.WriteLine(detained);
        }
    }

    public void PrintDates(string date)
    {
        foreach (var being in this.LivingBeings)
        {
            if (being.Birthdate.EndsWith(date))
            {
                Console.WriteLine(being.Birthdate);
            }
        }
    }
}