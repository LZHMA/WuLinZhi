using System;
using System.Collections.Generic;
using System.Text;

namespace WuLinZhi.Core.Force
{
    public class ForceBase
    {
        #region field
        private int _potentialHP;
        private int _potentialMP;
        private int _potentialVitality;
        private int _potentialStrength;
        private int _potentialAgility;
        #endregion

        #region property
        public ForceLevel Level { get; set; }
        public int Grade { get; set; }
        public int UpGradeCost
        {
            get => ((int)Level * (20) + 60) * Grade;
        }

        public int HP { get => Grade / 10 * _potentialHP; }
        public int MP { get => Grade / 10 * _potentialMP; }
        public int Vitality { get => Grade / 10 * _potentialVitality; }
        public int Strength { get => Grade / 10 * _potentialStrength; }
        public int Agility { get => Grade / 10 * _potentialAgility; }

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
