using InfernoInfinity.Contracts;
using System;

namespace InfernoInfinity.Gems
{
    public abstract class Gem : IGem
    {
        protected Gem(string qualityLevel, int strength, int agility, int vitality)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            this.Quality = (QualityLevel)Enum.Parse(typeof(QualityLevel), qualityLevel);
            IncreaseStatByQualityLevel();
        }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }

        public QualityLevel Quality { get; set; }

        private void IncreaseStatByQualityLevel()
        {
            this.Strength += (int)this.Quality;
            this.Agility += (int)this.Quality;
            this.Vitality += (int)this.Quality;
        }
    }
}