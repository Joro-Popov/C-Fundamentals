using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            Music music = new Music("Skandau", "album", 300, 20);
            StreamProgressInfo si = new StreamProgressInfo(music);

            Console.WriteLine(si.CalculateCurrentPercent());
        }
    }
}
