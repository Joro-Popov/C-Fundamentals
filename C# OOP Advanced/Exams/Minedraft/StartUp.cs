public class StartUp
{
    public static void Main(string[] args)
    {
        var reader = new Reader();
        var writer = new Writer();
        var energyRepo = new EnergyRepository();
        var harvesterController = new HarvesterController(energyRepo);
        var providerController = new ProviderController(energyRepo);
        var commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        Engine engine = new Engine(writer, reader, commandInterpreter);

        engine.Run();
    }
}