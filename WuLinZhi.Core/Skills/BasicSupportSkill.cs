using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;
using WuLinZhi.Core.Effects;

namespace WuLinZhi.Core.Skills
{
    public class BasicSupportSkill:SupportSkill
    {
        private BasicSupportSkill()
        {
            Name = "BasicSupport";
            MPCost = 0;
            ActionPointCost = 1;
        }
        public static BasicSupportSkill Skill = new BasicSupportSkill();
        public int GainShieldPercent { get; } = 100;
        public string Description
        {
            get => $"Gain {GainShieldPercent}% Vitality shield";
        }

        public override void Perform(CharacterInFight source)
        {
            MetaEffect.GainShield(source, GainShieldPercent);
        }
    }
}
