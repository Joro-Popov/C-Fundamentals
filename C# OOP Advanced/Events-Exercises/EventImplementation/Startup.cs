namespace EventImplementation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var handler = new Handler();
            var dispatcher = new Dispatcher();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string name;

            while ((name = Console.ReadLine()) != "End")
            {
                dispatcher.Name = name;
            }
        }
    }
}
