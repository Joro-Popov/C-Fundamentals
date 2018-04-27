using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    static void Main()
    {
        Corporation corporation = new Corporation();

        string command;

        while ((command = Console.ReadLine()) != "Paw Paw Pawah")
        {
            List<string> info = command
                .Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            switch (info[0])
            {
                case "RegisterCleansingCenter":
                    corporation.RegisterCleansingCenter(info[1]);
                    break;

                case "RegisterAdoptionCenter":
                    corporation.RegisterAdoptionCenter(info[1]);
                    break;

                case "RegisterCat":
                    Animal cat = new Cat(info[1],
                                         int.Parse(info[2]),
                                         int.Parse(info[3]),
                                         info[4]);
                    corporation.RegisterAnimal(cat);
                    break;

                case "RegisterDog":
                    Animal dog = new Dog(info[1],
                                         int.Parse(info[2]),
                                         int.Parse(info[3]),
                                         info[4]);
                    corporation.RegisterAnimal(dog);
                    break;

                case "SendForCleansing":
                    corporation.SendForClean(info[1], info[2]);
                    break;

                case "Cleanse":
                    corporation.Cleanse(info[1]);
                    break;

                case "Adopt":
                    corporation.Adopt(info[1]);
                    break;

                case "RegisterCastrationCenter":
                    corporation.RegisterCastrationCenter(info[1]);
                    break;

                case "SendForCastration":
                    corporation.SendForCastration(info[1], info[2]);
                    break;

                case "Castrate":
                    corporation.Castrate(info[1]);
                    break;

                case "CastrationStatistics":
                    Console.WriteLine(corporation.PrintCastrationStatistics());
                    break;
            }
        }

        Console.WriteLine(corporation);
    }
}
