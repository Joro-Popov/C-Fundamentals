namespace InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(string qualityLevel, string gemType);
    }
}