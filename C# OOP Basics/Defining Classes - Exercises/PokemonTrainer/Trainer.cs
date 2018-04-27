using System;
using System.Collections.Generic;
using System.Text;

public class Trainer
{
    public string Name { get; set; }
    public long BadgesCount { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Trainer(string name)
    {
        this.Name = name;
        this.BadgesCount = 0;
        this.Pokemons = new List<Pokemon>();
    }
}
