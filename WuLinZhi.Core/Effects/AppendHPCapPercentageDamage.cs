using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Effects
{
    public class AppendHPCapPercentageDamage:Effect
    {
        public AppendHPCapPercentageDamage(EffectOccasion occasion,int chance,int percentage)
        {
            Occasion = occasion;
            Chance = chance;
            Percentage = percentage;
        }

        public int Percentage { get; set; }
        

        public override void TakeEffect(CharacterInFight source,CharacterInFight target)
        {
            int damage = source.HPCap * Percentage / 100;
            MetaEffect.TakeDamage(target, damage);
        }

        public override string GetDescription()
        {
            var chanceDescription = Chance >= 100 ?String.Empty: $" by {Chance}% chance";

            var description = $"{Occasion},append damage of {Percentage}% HPCap{chanceDescription}";
            return description;
        }
    }
}
