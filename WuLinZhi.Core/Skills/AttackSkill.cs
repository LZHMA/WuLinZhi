using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Skills
{
    public abstract class AttackSkill : Skill
    {
        public int AttackRatio { get; set; }

        public abstract void Perform(CharacterInFight source,CharacterInFight target);
    }
}