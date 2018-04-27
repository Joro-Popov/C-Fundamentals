using InfernoInfinity.Contracts;
using System;
using System.Linq;

namespace InfernoInfinity.Weapons
{
    public abstract class Weapon : IWeapon
    {
        protected Weapon(string rarityLevel, string name, int minDamage, int maxDamage, int sockets)
        {
            this.Name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.Sockets = new IGem[sockets];
            this.Rarity = (RarityLevel)Enum.Parse(typeof(RarityLevel), rarityLevel.Split()[0]);
            ModifyByRarity();
        }

        public string Name { get; protected set; }

        public int MinDamage { get; protected set; }

        public int MaxDamage { get; protected set; }

        public IGem[] Sockets { get; protected set; }

        public RarityLevel Rarity { get; private set; }

        public int BonusStat => 0;

        private void ModifyByRarity()
        {
            this.MinDamage *= (int)this.Rarity;
            this.MaxDamage *= (int)this.Rarity;
        }

        private void IncreaseByBonusStat(IGem gem)
        {
            var StrengthProp = gem.GetType()
                    .GetProperty("Strength");

            var AglityProp = gem.GetType()
                .GetProperty("Agility");

            this.MinDamage += 2 * (int)StrengthProp.GetValue(gem);
            this.MaxDamage += 3 * (int)StrengthProp.GetValue(gem);

            this.MinDamage += 1 * (int)AglityProp.GetValue(gem);
            this.MaxDamage += 4 * (int)AglityProp.GetValue(gem);
        }

        private void DecreaseByBonusStat(IGem gem)
        {
            var StrengthProp = gem.GetType()
                    .GetProperty("Strength");

            var AglityProp = gem.GetType()
                .GetProperty("Agility");

            this.MinDamage -= 2 * (int)StrengthProp.GetValue(gem);
            this.MaxDamage -= 3 * (int)StrengthProp.GetValue(gem);

            this.MinDamage -= 1 * (int)AglityProp.GetValue(gem);
            this.MaxDamage -= 4 * (int)AglityProp.GetValue(gem);
        }

        public void AddGemToSocket(int socket, IGem gem)
        {
            if (socket >= 0 && socket < this.Sockets.Length)
            {
                this.Sockets[socket] = gem;
                //IncreaseByBonusStat(this.Sockets[socket]);
            }
        }

        public void RemoveGemFromSocket(int socket)
        {
            if (socket >= 0 && socket < this.Sockets.Length)
            {
                if (this.Sockets[socket] != null)
                {
                    //DecreaseByBonusStat(this.Sockets[socket]);
                    this.Sockets[socket] = null;
                }
            }
        }

        public override string ToString()
        {
            int strength = this.Sockets.Where(s => s != null).Sum(s => s.Strength);
            int agility = this.Sockets.Where(s => s != null).Sum(s => s.Agility);
            int vitality = this.Sockets.Where(s => s != null).Sum(s => s.Vitality);

            var minDamage = this.MinDamage + (strength * 2) + agility;
            var maxDamage = this.MaxDamage + (strength * 3) + (agility * 4);

            return $"{this.Name}: {minDamage}-{maxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
        }
    }
}