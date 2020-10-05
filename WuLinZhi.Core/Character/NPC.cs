using System.Collections.Generic;
using WuLinZhi.Core.Skills;

namespace WuLinZhi.Core.Character
{
    public class NPC: IFightable
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Vitality { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }

        public List<string> EquippedForces { get; } = new List<string>();

        public List<AttackSkill> AttackSkills { get; set; } = new List<AttackSkill>();
        public List<SupportSkill> SupportSkills { get; set; } = new List<SupportSkill>();
    }
}