using System;
using System.Collections.Generic;
using System.Text;

public class Track
{
    private int totalLaps;
    private int trackLength;
    private int currentLap;
    private Weather weather;

    public Track()
    {
        this.Weather = Weather.Sunny;
    }

    public int TotalLaps
    {
        get { return totalLaps; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidTime, this.CurrentLap));
            }
            totalLaps = value;
        }
    }

    public int CurrentLap
    {
        get { return currentLap; }
        set { currentLap = value; }
    }

    public int TrackLength
    {
        get { return trackLength; }
        set { trackLength = value; }
    }

    public Weather Weather
    {
        get { return this.weather; }
        set { this.weather = value; }
    }
}
