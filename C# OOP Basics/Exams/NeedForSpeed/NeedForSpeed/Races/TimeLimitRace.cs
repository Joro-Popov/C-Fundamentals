using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TimeLimitRace : Race
{
    private int goldTime;
    
    public TimeLimitRace(int length, string route, int prizePool, IEnumerable<Car> participants, int goldTime) 
        : base(length, route, prizePool, participants)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime
    {
        get { return goldTime; }
        private set { goldTime = value; }
    }

    public override void AddParticipant(Car car)
    {
        if (this.Participants.Count() < 1)
        {
            base.AddParticipant(car);
        }
    }

    public override string ToString()
    {
        Car participant = (this.Participants as List<Car>)[0];
        int points = participant.GetTimePerformance(this.Length);
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.AppendLine($"{participant.Brand} {participant.Model} - {points} s.");

        if (points <= this.GoldTime)
        {
            sb.AppendLine($"Gold Time, ${this.PrizePool}.");
        }
        else if (points <= this.GoldTime + 15)
        {
            sb.AppendLine($"Silver Time, ${(this.PrizePool * 50) / 100}.");
        }
        else if (points > this.GoldTime + 15)
        {
            sb.AppendLine($"Bronze Time, ${(this.PrizePool * 30) / 100}.");
        }

        return sb.ToString().Trim();
    }
}
