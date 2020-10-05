using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;
using WuLinZhi.Core.Effects;

namespace WuLinZhi.Core.Skills
{
    public class BasicAttackSkill : AttackSkill
    {
        private BasicAttackSkill()
        {
            Name = "BasicAttack";
            MPCost = 0;
            ActionPointCost = 1;
            AttackRatio = 100;
        }

        public static BasicAttackSkill Skill = new BasicAttackSkill();
        public string Description
        {
            get=> $"Cast {AttackRatio}% Strength attack";
        }

        public override void Perform(CharacterInFight source, CharacterInFight target)
        {
            MetaEffect.Attack(source,AttackRatio, target);
        }

    }
}
