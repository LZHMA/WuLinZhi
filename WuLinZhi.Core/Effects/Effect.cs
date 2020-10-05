using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Fight;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Effects
{
    public abstract class Effect
    {
        public static readonly Random EffectRandom;
        public EffectOccasion Occasion { get; set; }
        public int Chance { get; set; }

        internal bool TakeChance()
        {
            if (Chance >= 100)
                return true;
            return EffectRandom.Next(100) < Chance;
        }

        public abstract void TakeEffect(CharacterInFight source, CharacterInFight target);

        public abstract string GetDescription();
    }
}
