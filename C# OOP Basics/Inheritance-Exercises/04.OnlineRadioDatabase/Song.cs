using System;
using System.Collections.Generic;
using System.Linq;

public class Song
{
    private string artistName;
    private string songName;
    private string minutes;
    private string seconds;
    private List<string> info;
    private List<string> time;

    public Song(string input)
    {
        Info = input.Split(';').ToList();
        ArtistName = info[0];
        SongName = info[1];
        Time = info[2].Split(':').ToList();
        Minutes = Time[0];
        Seconds = Time[1];
    }

    public List<string> Time
    {
        get { return time; }
        private set
        {
            if (value.Count < 2 || value[0].Any(c => !char.IsDigit(c)) || value[1].Any(c => !char.IsDigit(c)))
            {
                throw new ArgumentException("Invalid song length.");
            }
            time = value;
        }
    }

    public List<string> Info
    {
        get { return info; }
        private set
        {
            if (value.Count < 3)
            {
                throw new ArgumentException("Invalid Song.");
            }
            info = value;
        }
    }

    public string Seconds
    {
        get { return seconds; }
        set
        {
            if (int.Parse(Time[1]) < 0 || int.Parse(Time[1]) > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
            seconds = value;
        }
    }

    public string Minutes
    {
        get { return minutes; }
        private set
        {
            if (int.Parse(Time[0]) < 0 || int.Parse(Time[0]) > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            minutes = value;
        }
    }

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }
            songName = value;
        }
    }

    public string ArtistName
    {
        get { return artistName; }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }
            artistName = value;
        }
    }
}