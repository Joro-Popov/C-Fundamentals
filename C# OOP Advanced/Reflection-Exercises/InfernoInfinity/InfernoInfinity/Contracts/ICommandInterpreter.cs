namespace InfernoInfinity.Contracts
{
    public interface ICommandInterpreter
    {
        string InterpretCommand(string commandName, string[] data);
    }
}