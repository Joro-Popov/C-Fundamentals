﻿public class Dog : Animal
{
    public Dog(string name, string food) : base(name, food)
    {
    }

    public override string ExplainSelf()
    {
        return $"{base.ExplainSelf()}\r\n" +
               $"DJAAF";
    }
}