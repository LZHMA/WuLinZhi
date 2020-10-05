using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Character;

namespace WuLinZhi.Core.Skills
{
    public abstract class SupportSkill:Skill
    {
        public abstract void Perform(CharacterInFight source);
    }
}
