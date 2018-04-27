using InfernoInfinity.Weapons;

namespace InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
        RarityLevel Rarity { get; }
        IGem[] Sockets { get; }

        void AddGemToSocket(int socket, IGem gem);

        void RemoveGemFromSocket(int socket);
    }
}