using System;

public class Startup
{
    static void Main()
    {
        Dog dog = new Dog();
        dog.Bark();
        dog = null;
    }
}
