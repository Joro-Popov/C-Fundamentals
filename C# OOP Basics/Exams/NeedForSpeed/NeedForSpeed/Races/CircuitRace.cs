using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CircuitRace : Race
{
    private int laps;
    
    public CircuitRace(int length, string route, int prizePool, IEnumerable<Car> participants, int laps) 
        : base(length, route, prizePool, participants)
    {
        this.Laps = laps;
    }

    public int Laps
    {
        get { return laps; }
        private set { laps = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        int position = 1;
        int prize = (this.PrizePool * 50) / 100;
        sb.AppendLine($"{this.Route} - {this.Length * this.laps}");

        for (int lap = 0; lap < laps; lap++)
        {
            foreach (var car in this.Participants)
            {
                car.ReduceDurability(this.Length);
            }
        }
        foreach (var car in this.Participants.OrderByDescending(d => d.GetOverallPerformance()).Take(4))
        {
            prize -= ((this.PrizePool * 10) / 100);
            sb.AppendLine($"{position}. {car.Brand} {car.Model} {car.GetOverallPerformance()}PP - ${prize}");
            position++;
        }

        return sb.ToString().Trim();
    }
}
