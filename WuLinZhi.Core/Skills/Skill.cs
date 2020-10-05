using System;
using System.Collections.Generic;
using System.Text;

namespace WuLinZhi.Core.Skills
{
    public abstract class Skill
    {
        public String Name { get; set; }
        public int ActionPointCost { get; set; }
        public int MPCost { get; set; }
    }
}
