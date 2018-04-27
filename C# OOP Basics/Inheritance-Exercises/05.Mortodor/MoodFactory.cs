using System.Collections.Generic;
using System.Linq;

public abstract class MoodFactory
{
    public static int Happiness(List<Food> foods)
    {
        return foods.Sum(f => f.Points);
    }

    public static Mood GetMood(int points)
    {
        if (points < -5) return new Angry();
        else if (points <= 0) return new Sad();
        else if (points <= 15) return new Happy();
        else return new JavaScript();
    }
}