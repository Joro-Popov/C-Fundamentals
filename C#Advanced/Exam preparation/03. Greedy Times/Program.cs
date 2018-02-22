using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Greedy_Times
{
    public class Bag
    {
        public long Capacity { get; set; }
        public long Gold { get; set; }
        public List<Gem> Gems { get; set; }
        public List<Cash> Cash { get; set; }

        public Bag(long capacity)
        {
            Capacity = 0;
            Gems = new List<Gem>();
            Cash = new List<Cash>();
        }
        
    }
    public class Gem
    {
        public string Type { get; set; }
        public long Amount { get; set; }

        public Gem(string type,long amount)
        {
            Type = type;
            Amount = amount;
        }
    }
    public class Cash
    {
        public long Amount { get; set; }
        public string Type { get; set; }

        public Cash(string type,long amount)
        {
            Type = type;
            Amount = amount;
        }
    }

    public class Program
    {
        public static void PutCashIntoTheBag(Bag bag, string item, long amount)
        {
            Cash cash = new Cash(item, amount);

            if (!bag.Cash.Any(w => w.Type == item))
            {
                if (bag.Cash.Sum(s => s.Amount) <= bag.Gems.Sum(s => s.Amount))
                {
                    bag.Cash.Add(cash);
                }
                
            }
            else
            {
                foreach (var csh in bag.Cash)
                {
                    if (csh.Type == item)
                    {
                        csh.Amount += amount;
                    }
                }
            }
            
        }
        public static void PutGemsInTheBag(Bag bag, string item, long amount)
        {
            Gem gem = new Gem(item, amount);

            if (!bag.Gems.Any(g => g.Type == item))
            {
                if (bag.Gold >= bag.Gems.Sum(s => s.Amount))
                {
                    bag.Gems.Add(gem);
                }
                
            }
            else
            {
                foreach (var g in bag.Gems)
                {
                    if (g.Type == item)
                    {
                        g.Amount += amount;
                    }
                }
            }
        }

        public static void Main()
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            
            List<string> wealth = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Bag bag = new Bag(bagCapacity);
            
            for (int i = 0; i <= wealth.Count - 2; i+=2)
            {
                string item = wealth[i];
                long amount = long.Parse(wealth[i + 1]);
                bool goesToBag = false;

                if (bag.Capacity + amount <= bagCapacity)
                {
                    if (item.All(w => char.IsUpper(w)))
                    {
                        PutCashIntoTheBag(bag, item, amount);
                        goesToBag = true;
                    }
                    else if (item.Contains("gem"))
                    {
                        PutGemsInTheBag(bag, item, amount);
                        goesToBag = true;
                    }
                    else if (item == "Gold")
                    {
                        bag.Gold += amount;
                        goesToBag = true;
                    }
                    if (goesToBag)
                    {
                        bag.Capacity += amount;
                    }
                    
                }
                
            }

            Console.WriteLine($"<Gold> {bag.Gold}");
            Console.WriteLine($"##Gold - {bag.Gold}");

            Console.WriteLine($"<Gem> {bag.Gems.Sum(s => s.Amount)}");

            foreach (var gem in bag.Gems.OrderBy(w => w.Type).ThenBy(w => w.Amount))
            {
                Console.WriteLine($"##{gem.Type} - {gem.Amount}");
            }

            Console.WriteLine($"<Cash> {bag.Cash.Sum(s => s.Amount)}");

            foreach (var cash in bag.Cash.OrderBy(w => w.Type).ThenBy(w => w.Amount))
            {
                Console.WriteLine($"##{cash.Type} - {cash.Amount}");
            }
        }
        
    }
}
