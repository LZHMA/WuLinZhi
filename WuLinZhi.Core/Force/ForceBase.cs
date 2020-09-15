using System;
using System.Collections.Generic;
using System.Text;

namespace WuLinZhi.Core.Force
{
    public class ForceBase
    {
        #region property
        public ForceLevel Level { get; set; }
        public int Grade { get; set; }
        public int UpGradeCost
        {
            get => ((int)Level * (20) + 60) * Grade;
        }

        public int HP { get; set; }
        public int MP { get; set; }
        public int Vitality { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }

        public int MetalPhase { get; set; }
        public int WoodPhase { get; set; }
        public int WaterPhase { get; set; }
        public int FirePhase { get; set; }
        public int EarthPahse { get; set; }
        #endregion

    }

    public enum ForceLevel
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
    }
}
