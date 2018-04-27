using System;
using System.Collections.Generic;

public class Stats
{
    private const double MinValue = 0;
    private const double MaxValue = 100;

    private double endurance;
    private double sprint;
    private double dribble;
    private double passing;
    private double shooting;
    private double skillLevel;

    public double SkillLevel
    {
        get { return skillLevel; }
        set { skillLevel = value; }
    }

    public double Shooting
    {
        get { return shooting; }
        private set
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException($"Shooting should be between 0 and 100.");
            }
            shooting = value;
        }
    }

    public double Passing
    {
        get { return passing; }
        private set
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException($"Passing should be between 0 and 100.");
            }
            passing = value;
        }
    }

    public double Dribble
    {
        get { return dribble; }
        private set
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException($"Dribble should be between 0 and 100.");
            }
            dribble = value;
        }
    }

    public double Sprint
    {
        get { return sprint; }
        private set
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException($"Sprint should be between 0 and 100.");
            }
            sprint = value;
        }
    }

    public double Endurance
    {
        get { return endurance; }
        private set
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException($"Endurance should be between 0 and 100.");
            }
            endurance = value;
        }
    }

    public Stats(Queue<string> info)
    {
        Endurance = double.Parse(info.Dequeue());
        Sprint = double.Parse(info.Dequeue());
        Dribble = double.Parse(info.Dequeue());
        Passing = double.Parse(info.Dequeue());
        Shooting = double.Parse(info.Dequeue());
        skillLevel = (Endurance + Sprint + Dribble + Passing + Shooting) / 5;
    }
}