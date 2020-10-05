using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WuLinZhi.Core.Buffs;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Effects
{
    public class AppendBleedingBuffToEnemy:Effect
    {
        public AppendBleedingBuffToEnemy(EffectOccasion occasion,int chance,int layer)
        {
            Occasion = occasion;
            Chance = chance;
            Layer = layer;
        }

        public int Layer { get; }

        public override void TakeEffect(CharacterInFight source, CharacterInFight target)
        {
            if (!TakeChance())
                return;
            target.Buffs.AppendBuff(new Bleeding(),Layer);
        }

        public override string GetDescription()
        {
            var chanceDescription = Chance >= 100 ? String.Empty : $" by {Chance}% chance";

            var description = $"{Occasion},append {Layer} layer Bleeding buff{chanceDescription}";
            return description;
        }
    }
}
