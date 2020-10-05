using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Effects
{
    public class RoundEndDebuffAct:Effect
    {
        public RoundEndDebuffAct()
        {
            Occasion = EffectOccasion.RoundEnd;
            Chance = 100;
        }

        public override void TakeEffect(CharacterInFight source, CharacterInFight target)
        {
            throw new NotImplementedException();
        }

        public override string GetDescription()
        {

            var description = $"Round end DeBuff act";
            return description;
        }
    }
}
