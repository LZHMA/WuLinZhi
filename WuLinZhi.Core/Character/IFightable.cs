using System;
using System.Collections.Generic;
using System.Text;
using WuLinZhi.Core.Skills;

namespace WuLinZhi.Core.Character
{
    public interface IFightable
    {
        string Name { get; set; }
        int HP { get; set; }
        int MP { get; set; }
        int Vitality { get; set; }
        int Strength { get; set; }
        int Agility { get; set; }

        List<string> EquippedForces { get; }

        List<AttackSkill> AttackSkills { get; set; }
        List<SupportSkill> SupportSkills { get; set; }
    }
}
