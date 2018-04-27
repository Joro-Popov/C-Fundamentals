using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        var cats = new Dictionary<string, Cat>();
        string catsinfo;
        while ((catsinfo = Console.ReadLine()) != "End")
        {
            List<string> info = catsinfo
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Cat cat = new Cat(info[0], info[1], info[2]);
            cats[cat.Name] = cat;
        }
        string toPrint = Console.ReadLine();
        Cat current = cats[toPrint];
        switch (current.Breed)
        {
            case "Siamese": Console.WriteLine($"{current.Breed} {current.Name} {int.Parse(current.Spec)}"); break;
            case "Cymric": Console.WriteLine($"{current.Breed} {current.Name} {decimal.Parse(current.Spec):f2}"); break;
            case "StreetExtraordinaire": Console.WriteLine($"{current.Breed} {current.Name} {int.Parse(current.Spec)}"); break;
        }
    }
}
