using System;
using System.Collections.Generic;
using System.Text;

namespace WuLinZhi.Core.Skills
{
    public abstract class Skill
    {
        public String Name { get; set; }
        public int ActionPoint { get; set; }
        public int MP { get; set; }
    }
}
