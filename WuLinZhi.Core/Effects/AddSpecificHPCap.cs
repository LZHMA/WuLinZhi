using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Effects
{
    public class AddSpecificHPCap:Effect
    {
        public AddSpecificHPCap(EffectOccasion occasion, int chance, int hp)
        {
            Occasion = occasion;
            Chance = chance;
            HP = hp;
        }

        public int HP { get; set; }

        public override void TakeEffect(CharacterInFight source, CharacterInFight target)
        {
            if (!TakeChance())
            {
                return;
            }

            source.HPCap += HP;
        }

        public override string GetDescription()
        {
            var chanceDescription = Chance >= 100 ? String.Empty : $" by {Chance}% chance";

            var description = $"{Occasion},increse {HP} HPCap{chanceDescription}";
            return description;
        }
    }
}
