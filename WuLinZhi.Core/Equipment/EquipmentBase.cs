using System;
using System.Collections.Generic;
using System.Text;

namespace WuLinZhi.Core.Equipment
{
    public class EquipmentBase
    {
        public string Name { get; set; }

        public int HP { get; set; }
        public int MP { get; set; }
        public int Vitiality { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }

        public int HPAmplification { get; set; }
        public int MPAmplification { get; set; }
        public int VitalityAmplification { get; set; }
        public int StrengthAmplification { get; set; }
        public int AgilityAmplification { get; set; }

        public int Price { get; set; }

        public EquipmentType Type { get; set; }
    }
}
