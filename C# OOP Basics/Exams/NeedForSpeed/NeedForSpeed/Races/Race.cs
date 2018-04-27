using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private IEnumerable<Car> participants;

    protected Race(int length, string route, int prizePool, IEnumerable<Car> participants)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = participants;
    }

    public IEnumerable<Car> Participants
    {
        get { return participants; }
        private set { participants = value; }
    }
    
    public int PrizePool
    {
        get { return prizePool; }
        private set { prizePool = value; }
    }

    public string Route
    {
        get { return route; }
        private set { route = value; }
    }

    public int Length
    {
        get { return length; }
        private set { length = value; }
    }

    public virtual void AddParticipant(Car car)
    {
        (this.Participants as List<Car>).Add(car);
    }

    public override string ToString()
    {
        return $"{this.Route} - {this.Length}";
    }
}
