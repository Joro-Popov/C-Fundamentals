using System;
using System.Collections.Generic;

public class RadioStationDatabase
{
    private List<Song> songs;

    public RadioStationDatabase()
    {
        Songs = new List<Song>();
    }

    public List<Song> Songs
    {
        get { return songs; }
        private set { songs = value; }
    }

    public void AddSong(Song song)
    {
        Songs.Add(song);
        Console.WriteLine($"Song added.");
    }

    public string PlaylistLength()
    {
        int seconds = 0;

        foreach (var song in songs)
        {
            seconds += int.Parse(song.Minutes) * 60;
            seconds += int.Parse(song.Seconds);
        }
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        return $"{time.Hours.ToString()}h {time.Minutes.ToString()}m {time.Seconds.ToString()}s";
    }
}