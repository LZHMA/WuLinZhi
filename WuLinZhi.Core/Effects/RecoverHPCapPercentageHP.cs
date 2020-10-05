using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Effects
{
    public class RecoverHPCapPercentageHP:Effect
    {
        public RecoverHPCapPercentageHP(EffectOccasion occasion, int chance, int percentage)
        {
            Occasion = occasion;
            Chance = chance;
            Percentage = percentage;
        }

        public int Percentage { get; set; }
        public override void TakeEffect(CharacterInFight source, CharacterInFight target)
        {
            int recover = source.HPCap * Percentage / 100;
            MetaEffect.TakeHPRecover(source, recover);
        }
        public override string GetDescription()
        {
            var chanceDescription = Chance >= 100 ? String.Empty : $" by {Chance}% chance";

            var description = $"{Occasion},recover HP of {Percentage}% HPCap{chanceDescription}";
            return description;
        }
    }
}
