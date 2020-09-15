using System;
using System.Collections.Generic;
using System.Text;

namespace WuLinZhi.Core.Effects
{
    public abstract class Effect
    {
        public string Name { get; set; }
        public EffectOccasion Occasion { get; set; }
        public int Chance { get; set; }

        public bool Trigger()
        {
            var random = new Random().Next(100);
            return random < Chance;
        }

        public abstract void TakeEffect();
    }

    public enum EffectOccasion
    {
        FightStart=0,
        RoundStart=1,
        Attacting=2,
        Attacted=3,
        RoundEnd=4,
    }
}
