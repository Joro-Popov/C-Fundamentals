using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool, ICollection<Car> participants) 
        : base(length, route, prizePool, participants)
    {
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        int position = 1;
        Queue<int> Prizes = new Queue<int>();
        Prizes.Enqueue((this.PrizePool * 50) / 100);
        Prizes.Enqueue((this.PrizePool * 30) / 100);
        Prizes.Enqueue((this.PrizePool * 20) / 100);
        
        sb.AppendLine(base.ToString());

        foreach (var participant in this.Participants.OrderByDescending(p => p.GetSuspensionPerformance()).Take(3))
        {
            sb.AppendLine($"{position}. {participant.Brand} {participant.Model} {participant.GetSuspensionPerformance()}PP - ${Prizes.Dequeue()}");
            position++;
        }

        return sb.ToString().Trim();
    }
}
