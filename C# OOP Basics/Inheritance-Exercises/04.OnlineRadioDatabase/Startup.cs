using System;

public class Startup
{
    private static void Main()
    {
        RadioStationDatabase radio = new RadioStationDatabase();
        int songsCount = int.Parse(Console.ReadLine());
        for (int count = 0; count < songsCount; count++)
        {
            try
            {
                Song song = new Song(Console.ReadLine());
                radio.AddSong(song);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine($"Songs added: {radio.Songs.Count}");
        Console.WriteLine($"Playlist length: {radio.PlaylistLength()}");
    }
}